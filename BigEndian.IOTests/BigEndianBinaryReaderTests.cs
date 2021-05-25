using BigEndian.IO;
using NUnit.Framework;
using System;
using System.IO;

namespace BigEndian.IOTests
{
    public class BigEndianBinaryReaderTests
    {
        MemoryStream stream;
        BinaryWriter littleEndianWriter;
        BigEndianBinaryReader bigEndianReader;

        [SetUp]
        public void Setup()
        {
            stream = new MemoryStream();
            littleEndianWriter = new BinaryWriter(stream);
            bigEndianReader = new BigEndianBinaryReader(stream);
        }

        [TearDown]
        public void Teardown()
        {
            stream.Dispose();
        }

        [Test]
        public void ReadBigEndianSingle_NotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => bigEndianReader.ReadBigEndianSingle());
        }

        [Test]
        public void ReadBigEndianDouble_NotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => bigEndianReader.ReadBigEndianDouble());
        }

        [Test]
        public void ReadBigEndianDecimal_NotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => bigEndianReader.ReadBigEndianDecimal());
        }

        [TestCase(unchecked((short)0x0100), unchecked((short)0x0001))]
        [TestCase(unchecked((short)0x0001), unchecked((short)0x0100))]
        [TestCase(unchecked((short)0xfeff), unchecked((short)0xfffe))]
        public void ReadBigEndianInt16_Succeeds(short bigEndian, short littleEndian)
        {
            littleEndianWriter.Write(bigEndian);
            stream.Position = 0;

            Assert.That(bigEndianReader.ReadBigEndianInt16(), Is.EqualTo(littleEndian));
        }

        [TestCase(unchecked((ushort)0x0100), unchecked((ushort)0x0001))]
        [TestCase(unchecked((ushort)0x0001), unchecked((ushort)0x0100))]
        [TestCase(unchecked((ushort)0xfeff), unchecked((ushort)0xfffe))]
        public void ReadBigEndianUInt16_Succeeds(ushort bigEndian, ushort littleEndian)
        {
            littleEndianWriter.Write(bigEndian);
            stream.Position = 0;

            Assert.That(bigEndianReader.ReadBigEndianUInt16(), Is.EqualTo(littleEndian));
        }

        [TestCase(unchecked((int)0x01000000), unchecked((int)0x00000001))]
        [TestCase(unchecked((int)0x00010000), unchecked((int)0x00000100))]
        [TestCase(unchecked((int)0xfeffffff), unchecked((int)0xfffffffe))]
        public void ReadBigEndianInt32_Succeeds(int bigEndian, int littleEndian)
        {
            littleEndianWriter.Write(bigEndian);
            stream.Position = 0;

            Assert.That(bigEndianReader.ReadBigEndianInt32(), Is.EqualTo(littleEndian));
        }

        [TestCase(unchecked((uint)0x01000000), unchecked((uint)0x00000001))]
        [TestCase(unchecked((uint)0x00010000), unchecked((uint)0x00000100))]
        [TestCase(unchecked((uint)0xfeffffff), unchecked((uint)0xfffffffe))]
        public void ReadBigEndianUInt32_Succeeds(uint bigEndian, uint littleEndian)
        {
            littleEndianWriter.Write(bigEndian);
            stream.Position = 0;

            Assert.That(bigEndianReader.ReadBigEndianUInt32(), Is.EqualTo(littleEndian));
        }

        [TestCase(unchecked((long)0x0100000000000000), unchecked((long)0x0000000000000001))]
        [TestCase(unchecked((long)0x0001000000000000), unchecked((long)0x0000000000000100))]
        [TestCase(unchecked((long)0xfeffffffffffffff), unchecked((long)0xfffffffffffffffe))]
        public void ReadBigEndianInt64_Succeeds(long bigEndian, long littleEndian)
        {
            littleEndianWriter.Write(bigEndian);
            stream.Position = 0;

            Assert.That(bigEndianReader.ReadBigEndianInt64(), Is.EqualTo(littleEndian));
        }

        [TestCase(unchecked((ulong)0x0100000000000000), unchecked((ulong)0x0000000000000001))]
        [TestCase(unchecked((ulong)0x0001000000000000), unchecked((ulong)0x0000000000000100))]
        [TestCase(unchecked((ulong)0xfeffffffffffffff), unchecked((ulong)0xfffffffffffffffe))]
        public void ReadBigEndianUInt64_Succeeds(ulong bigEndian, ulong littleEndian)
        {
            littleEndianWriter.Write(bigEndian);
            stream.Position = 0;

            Assert.That(bigEndianReader.ReadBigEndianUInt64(), Is.EqualTo(littleEndian));
        }
    }
}
