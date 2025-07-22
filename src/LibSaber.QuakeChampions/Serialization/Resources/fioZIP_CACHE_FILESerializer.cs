using LibSaber.IO;
using LibSaber.Serialization;
using LibSaber.QuakeChampions.Structures.Resources;

namespace LibSaber.QuakeChampions.Serialization.Resources;

public class fioZIP_CACHE_FILESerializer : QCSerializerBase<fioZIP_CACHE_FILE>
{

  public override fioZIP_CACHE_FILE Deserialize(NativeReader reader, ISerializationContext context)
  {
    var cache = new fioZIP_CACHE_FILE();

    // Update 7: Cache files now have 0x20 bytes at the top. Hash/Checksum?
    // TODO: Detect this in a better way

    bool isVersion7Plus = false;
    var peek = reader.ReadInt32();
    reader.Position -= 4;
    if (peek > 5 || peek < 1)
    {
      isVersion7Plus = true;
      //reader.Position += 0x20;
    }
    var position = reader.Position.ToString();
    while (reader.Position < reader.Length)
    {
      var version = reader.ReadInt32();
      position += " " + reader.Position.ToString();

      var unk_04 = reader.ReadByte();
      position += " " + reader.Position.ToString();
      var entry = new fioZIP_CACHE_FILE.ENTRY
      {
        FileName = reader.ReadLengthPrefixedString32(),
        Offset = reader.ReadInt64(),
        Size = reader.ReadInt64(),
        CompressedSize = reader.ReadInt64(),
        CompressMethod = (fioZIP_CACHE_FILE.COMPRESS_METHOD)reader.ReadInt16(),
      };
      position += " " + reader.Position.ToString();
      

      if (isVersion7Plus)
        _ = reader.ReadInt64();
      else if (version > 5 && !isVersion7Plus)
        _ = reader.ReadInt32(); //CRC?

      
      cache.AddEntry(entry);
    }

    return cache;
  }


}