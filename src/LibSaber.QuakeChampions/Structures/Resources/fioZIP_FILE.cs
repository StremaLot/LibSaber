using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSaber.IO;
using LibSaber.QuakeChampions.Serialization;

namespace LibSaber.QuakeChampions.Structures.Resources;

public class fioZIP_FILE : IDisposable
{

  private readonly MemoryMappedFile _file;
  private readonly fioZIP_CACHE_FILE _cacheFile;

  private bool _isDisposed;

  public IReadOnlyDictionary<string, fioZIP_CACHE_FILE.ENTRY> Entries => _cacheFile;

  private fioZIP_FILE(MemoryMappedFile file, fioZIP_CACHE_FILE cacheFile)
  {
    _file = file;
    _cacheFile = cacheFile;
  }

  public static fioZIP_FILE Open(string filePath)
  {
    if (Path.GetExtension(filePath) != ".pak")
      throw new Exception($"File is not a PAK: {filePath}");

    var cacheFile = ReadCacheFile(filePath);
    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
    var file = MemoryMappedFile.CreateFromFile(fileStream, null, 0, MemoryMappedFileAccess.Read, HandleInheritability.None, false);

    return new fioZIP_FILE(file, cacheFile);
  }

  public Stream GetFileStream(string fileName)
  {
    if (!_cacheFile.TryGetValue(fileName, out var entry))
      throw new Exception($"File not found: {fileName}");

    return GetFileStream(entry);
  }

  public Stream GetFileStream(fioZIP_CACHE_FILE.ENTRY entry)
  {
    if( entry.CompressMethod == fioZIP_CACHE_FILE.COMPRESS_METHOD.STORE)
      return GetFileStreamNoCompression(entry);

        return GetFileStreamDeflate(entry);//, @"D:\Games\test\test.zip");
  }

  private Stream GetFileStreamNoCompression(fioZIP_CACHE_FILE.ENTRY entry)
  {
    return _file.CreateViewStream(
      entry.Offset, 
      entry.CompressedSize,
      MemoryMappedFileAccess.Read);
  }

  private Stream GetFileStreamDeflate(fioZIP_CACHE_FILE.ENTRY entry, string? outputFilePath = null, bool writeRawCompressed = false)
  {
    using var compressedStream = _file.CreateViewStream(
      entry.Offset, 
      entry.CompressedSize, 
      MemoryMappedFileAccess.Read);

    if (!string.IsNullOrEmpty(outputFilePath) && writeRawCompressed)
    {
      using var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
      compressedStream.CopyTo(fileStream);
      // Возвращаем пустой MemoryStream для совместимости с сигнатурой
      return new MemoryStream();
    }

    using var deflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress);

    if (!string.IsNullOrEmpty(outputFilePath))
    {
      using var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
      deflateStream.CopyTo(fileStream);
      // После записи возвращаем пустой MemoryStream, чтобы соответствовать сигнатуре
      return new MemoryStream();
    }
    else
    {
      var memoryStream = new MemoryStream();
      deflateStream.CopyTo(memoryStream);
      memoryStream.Position = 0;
      return memoryStream;
    }
  }

  private static fioZIP_CACHE_FILE ReadCacheFile(string filePath)
  {
    var cacheFilePath = filePath + ".cache";
    if (!File.Exists(cacheFilePath))
    {
        var cacheFile = BuildCacheFromPak(filePath);
        using (var cacheFileStream = File.Create(cacheFilePath))
        {
            var writer = new NativeWriter(cacheFileStream, Endianness.LittleEndian);
            Serialization.Resources.fioZIP_CACHE_FILESerializer2.Serialize(writer, cacheFile);
            }
        return cacheFile;
    }

    using (var cacheFileStream = File.OpenRead(cacheFilePath))
    {
        var reader = new NativeReader(cacheFileStream, Endianness.LittleEndian);
        return Serializer<fioZIP_CACHE_FILE>.Deserialize(reader);
    }
  }

  private static fioZIP_CACHE_FILE BuildCacheFromPak(string filePath)
  {
    var cache = new fioZIP_CACHE_FILE();
    using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
    // 1. Прочитать ключ (последние 40 байт файла)
    fs.Seek(-40, SeekOrigin.End);
    byte[] key = new byte[40];
    fs.Read(key, 0, 40);

    // 2. Инициализировать дешифратор
    var decryptor = new QuakeDecryptor(key);

    // 3. Найти сигнатуру "PK\x06\x06" (центральная директория ZIP64) с конца файла
    long pk0606Offset = FindSignatureFromEnd(fs, new byte[] { 0x50, 0x4B, 0x06, 0x06 });
    if (pk0606Offset < 0)
        throw new Exception("PK\\x06\\x06 signature not found in the file");

    fs.Seek(pk0606Offset, SeekOrigin.Begin);
    byte[] sig = new byte[4];
    fs.Read(sig, 0, 4); // "PK\x06\x06"
    fs.ReadByte(); // ZERO
    long centralEntries = ReadInt64LE(fs);
    long centralSize = ReadInt64LE(fs);
    long centralOffset = ReadInt64LE(fs);
    fs.Seek(8, SeekOrigin.Current); // DUMMY_offset

    // 4. Перейти к центральной директории
    fs.Seek(centralOffset, SeekOrigin.Begin);

    for (long i = 0; i < centralEntries; i++)
    {
        if (i == 3254)
            {
                checkWhatGoinON(i);
            }
        // 5. Прочитать и дешифровать заголовок файла (0x2e байт)
        long entryStart = fs.Position;
        byte[] entryHeader = new byte[0x2e];
        fs.Read(entryHeader, 0, entryHeader.Length);
        decryptor.Decrypt(entryHeader, 0, entryHeader.Length);

        using var entryStream = new MemoryStream(entryHeader);
        if (!CheckSignature(entryStream, new byte[] { 0x50, 0x4B, 0x01, 0x02 }))
            throw new Exception("Central directory entry signature mismatch");

        ushort verMade = ReadUInt16LE(entryStream);
        ushort verNeed = ReadUInt16LE(entryStream);
        ushort flag = ReadUInt16LE(entryStream);
        ushort method = ReadUInt16LE(entryStream);
        ushort modtime = ReadUInt16LE(entryStream);
        ushort moddate = ReadUInt16LE(entryStream);
        uint zipCrc = ReadUInt32LE(entryStream);
        uint compSize = ReadUInt32LE(entryStream);
        uint uncompSize = ReadUInt32LE(entryStream);
        ushort nameLen = ReadUInt16LE(entryStream);
        ushort extraLen = ReadUInt16LE(entryStream);
        ushort commLen = ReadUInt16LE(entryStream);
        ushort disknum = ReadUInt16LE(entryStream);
        ushort intAttr = ReadUInt16LE(entryStream);
        uint extAttr = ReadUInt32LE(entryStream);
        long relOffset = ReadUInt32LE(entryStream);

        // 6. Прочитать и дешифровать имя файла
        fs.Seek(entryStart + 0x2e, SeekOrigin.Begin);
        byte[] nameBytes = new byte[nameLen];
        fs.Read(nameBytes, 0, nameLen);
        decryptor.Decrypt(nameBytes, 0, nameLen);
        string fileName = Encoding.UTF8.GetString(nameBytes);

        // 7. Прочитать extra и comment
        byte[] extra = new byte[extraLen];
        fs.Read(extra, 0, extraLen);
        byte[] comment = new byte[commLen];
        fs.Read(comment, 0, commLen);

        // 8. Обработка rel_offset для ZIP64
        if (extraLen >= 12)
        {
            ushort extraId = BitConverter.ToUInt16(extra, 0);
            if (extraId == 0x01 && relOffset == 0xffffffff)
            {
                relOffset = BitConverter.ToInt64(extra, 4);
                checkWhatGoinON(i);
            }
        }

        // 9. Добавить в cache
        var entry = new fioZIP_CACHE_FILE.ENTRY
        {
            FileName = fileName,
            Offset = 0x1e + relOffset,
            CompressedSize = compSize,
            Size = uncompSize,
            CompressMethod = (fioZIP_CACHE_FILE.COMPRESS_METHOD)method
        };
        cache.AddEntry(entry);

        // 10. Перейти к следующей записи
        fs.Seek(entryStart + 0x2e + nameLen + extraLen + commLen, SeekOrigin.Begin);
    }
    return cache;
  }
    private static void checkWhatGoinON(long i)
    { 
        long a = i; 
    }

  private static long FindSignatureFromEnd(Stream stream, byte[] signature)
  {
    const int bufferSize = 4096;
    byte[] buffer = new byte[bufferSize];
    long fileLength = stream.Length;
    long position = fileLength;

    while (position > 0)
    {
      int readSize = (int)Math.Min(bufferSize, position);
      position -= readSize;
      stream.Seek(position, SeekOrigin.Begin);
      stream.Read(buffer, 0, readSize);

      for (int i = readSize - signature.Length; i >= 0; i--)
      {
        bool match = true;
        for (int j = 0; j < signature.Length; j++)
        {
          if (buffer[i + j] != signature[j])
          {
            match = false;
            break;
          }
        }
        if (match)
        {
          return position + i;
        }
      }
    }
    return -1;
  }

  private static bool CheckSignature(Stream stream, byte[] signature)
  {
    byte[] buffer = new byte[signature.Length];
    stream.Read(buffer, 0, buffer.Length);
    return buffer.SequenceEqual(signature);
  }

  private static ushort ReadUInt16LE(Stream s)
  {
    byte[] buffer = new byte[2];
    s.Read(buffer, 0, buffer.Length);
    return BitConverter.ToUInt16(buffer, 0);
  }

  private static uint ReadUInt32LE(Stream s)
  {
    byte[] buffer = new byte[4];
    s.Read(buffer, 0, buffer.Length);
    return BitConverter.ToUInt32(buffer, 0);
  }

  private static long ReadInt64LE(Stream s)
  {
    byte[] buffer = new byte[8];
    s.Read(buffer, 0, buffer.Length);
    return BitConverter.ToInt64(buffer, 0);
  }

  public void Dispose()
  {
    _file?.Dispose();
    _isDisposed = true;
  }

}
