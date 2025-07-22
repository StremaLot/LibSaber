using System;
using System.IO;
using System.Text;

namespace LibSaber.IO;


public class NativeWriter : IDisposable
{
    private readonly Stream _stream;
    private readonly Endianness _endianness;
    private readonly bool _leaveOpen;

    public NativeWriter(Stream stream, Endianness endianness, bool leaveOpen = false)
    {
        _stream = stream;
        _endianness = endianness;
        _leaveOpen = leaveOpen;
    }

    public void Write(int value)
    {
        Write(BitConverter.GetBytes(value));
    }

    public void Write(long value)
    {
        Write(BitConverter.GetBytes(value));
    }

    public void Write(uint value)
    {
        Write(BitConverter.GetBytes(value));
    }

    public void Write(ulong value)
    {
        Write(BitConverter.GetBytes(value));
    }

    public void Write(short value)
    {
        Write(BitConverter.GetBytes(value));
    }

    public void Write(ushort value)
    {
        Write(BitConverter.GetBytes(value));
    }

    public void Write(byte value)
    {
        _stream.WriteByte(value);
    }

    public void WriteLengthPrefixedString32(string value)
    {
        if (value == null)
        {
            Write(0);
            return;
        }
        var bytes = Encoding.UTF8.GetBytes(value);
        Write(bytes.Length);
        Write(bytes);
    }

    public void Write(byte[] buffer)
    {
        if (_endianness == Endianness.LittleEndian)
            _stream.Write(buffer, 0, buffer.Length);
        else
        {
            Array.Reverse(buffer);
            _stream.Write(buffer, 0, buffer.Length);
        }
    }

    public void Write(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        Write((ushort)bytes.Length);
        Write(bytes);
    }

    public void Dispose()
    {
        if (!_leaveOpen)
            _stream.Dispose();
    }
}