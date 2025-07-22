using LibSaber.IO;
using LibSaber.QuakeChampions.Structures.Resources;

namespace LibSaber.QuakeChampions.Serialization.Resources;

public static class fioZIP_CACHE_FILESerializer2
{
    public static void Serialize(NativeWriter writer, fioZIP_CACHE_FILE cacheFile)
    {
        // Для простоты: сериализуем все записи как version = 6, unk_04 = 0
        foreach (var entry in cacheFile.Values)
        {
            writer.Write(6); // version
            writer.Write((byte)0); // unk_04

            writer.WriteLengthPrefixedString32(entry.FileName);
            writer.Write(entry.Offset);
            writer.Write(entry.Size);
            writer.Write(entry.CompressedSize);
            writer.Write((short)entry.CompressMethod);

            writer.Write((long)0);
            

            // Для совместимости с версией 6 можно добавить CRC = 0
            // writer.Write(0); // CRC (если потребуется)
        }
    }
}