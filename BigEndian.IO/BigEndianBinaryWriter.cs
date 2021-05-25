using System;
using System.IO;
using System.Text;
using System.Net;

namespace BigEndian.IO
{
    public class BigEndianBinaryWriter : BinaryWriter
    {
        public BigEndianBinaryWriter(Stream output) : base(output)
        {
        }

        public BigEndianBinaryWriter(Stream output, Encoding encoding) : base(output, encoding)
        {
        }

        public BigEndianBinaryWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen)
        {
        }

        public virtual void WriteBigEndian(float value)
        {
            throw new NotImplementedException();
        }

        public virtual void WriteBigEndian(double value)
        {
            throw new NotImplementedException();
        }

        public virtual void WriteBigEndian(decimal value)
        {
            throw new NotImplementedException();
        }

        public virtual void WriteBigEndian(short value)
        {
            base.Write(IPAddress.HostToNetworkOrder(value));
        }

        public virtual void WriteBigEndian(ushort value)
        {
            base.Write((ushort)IPAddress.HostToNetworkOrder((short)value));
        }

        public virtual void WriteBigEndian(int value)
        {
            base.Write(IPAddress.HostToNetworkOrder(value));
        }

        public virtual void WriteBigEndian(uint value)
        {
            base.Write((uint)IPAddress.HostToNetworkOrder((int)value));
        }

        public virtual void WriteBigEndian(long value)
        {
            base.Write(IPAddress.HostToNetworkOrder(value));
        }

        public virtual void WriteBigEndian(ulong value)
        {
            base.Write((ulong)IPAddress.HostToNetworkOrder((long)value));
        }
    }
}
