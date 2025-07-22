using System;

namespace LibSaber.QuakeChampions.Structures.Resources;

public class QuakeDecryptor
{
    private ulong u, v, w;
    private ulong qc_seed;
    private readonly byte[] qc_ivec = new byte[32];
    private ushort qc_seed_idx;
    private ushort qc_ivec_idx;

    public QuakeDecryptor(byte[] key)
    {
        if (key == null || key.Length < 8)
            throw new ArgumentException("Key must be at least 8 bytes long");

        // Инициализация qc_ivec (первые 32 байта ключа)
        Array.Copy(key, qc_ivec, 32);

        // qc_seed = первые 8 байт ключа как ulong (LE)
        qc_seed = BitConverter.ToUInt64(key, 0);

        qc_seed_idx = 0;
        qc_ivec_idx = 0;
        NrRandom(qc_seed);
    }

    private ulong NextUInt64()
    {
        u = u * 2862933555777941757UL + 7046029254386353087UL;
        v ^= v >> 17; v ^= v << 31; v ^= v >> 8;
        w = 4294957665U * (w & 0xffffffffUL) + (w >> 32);
        ulong x = u ^ (u << 21); x ^= x >> 35; x ^= x << 4;
        return (x + v) ^ w;
    }

    private void NrRandom(ulong seed)
    {
        v = 4101842887655102017UL;
        w = 1;
        u = v ^ seed ^ 0xCEEDUL;
        NextUInt64();
        v = u;
        NextUInt64();
        w = v;
        NextUInt64();
    }

    /// <summary>
    /// Дешифрует данные на месте (in-place)
    /// </summary>
    public void Decrypt(byte[] data, int offset, int size)
    {
        for (int i = 0; i < size; i++)
        {
            byte old = qc_ivec[qc_ivec_idx];
            qc_ivec[qc_ivec_idx] = data[offset + i];
            ulong xor = (qc_seed_idx == 0 ? qc_seed : 0) ^ old;
            data[offset + i] ^= (byte)(xor & 0xFF);
            qc_ivec_idx = (ushort)((qc_ivec_idx + 1) & 0x1F);
            if (++qc_seed_idx == 8)
            {
                qc_seed = NextUInt64();
                qc_seed_idx = 0;
            }
        }
    }

    /// <summary>
    /// Дешифрует весь массив данных
    /// </summary>
    public void Decrypt(byte[] data)
    {
        Decrypt(data, 0, data.Length);
    }
}