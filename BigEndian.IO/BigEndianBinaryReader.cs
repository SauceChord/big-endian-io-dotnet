using System;
using System.IO;
using System.Text;
using System.Net;

namespace BigEndian.IO
{
    public class BigEndianBinaryReader : BinaryReader
    {
        public BigEndianBinaryReader(Stream input) : base(input)
        {
        }

        public BigEndianBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public BigEndianBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public virtual float ReadBigEndianSingle()
        {
            throw new NotImplementedException();
        }

        public virtual double ReadBigEndianDouble()
        {
            throw new NotImplementedException();
        }

        public virtual decimal ReadBigEndianDecimal()
        {
            throw new NotImplementedException();
        }

        public virtual short ReadBigEndianInt16()
        {
            return IPAddress.NetworkToHostOrder(base.ReadInt16());
        }

        public virtual ushort ReadBigEndianUInt16()
        {
            return (ushort)IPAddress.NetworkToHostOrder(base.ReadInt16());
        }

        public virtual int ReadBigEndianInt32()
        {
            return IPAddress.NetworkToHostOrder(base.ReadInt32());
        }

        public virtual uint ReadBigEndianUInt32()
        {
            return (uint)IPAddress.NetworkToHostOrder(base.ReadInt32());
        }

        public virtual long ReadBigEndianInt64()
        {
            return IPAddress.NetworkToHostOrder(base.ReadInt64());
        }

        public virtual ulong ReadBigEndianUInt64()
        {
            return (ulong)IPAddress.NetworkToHostOrder(base.ReadInt64());
        }
    }
}
