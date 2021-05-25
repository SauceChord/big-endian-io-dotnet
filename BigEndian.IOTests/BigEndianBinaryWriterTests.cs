using BigEndian.IO;
using NUnit.Framework;
using System;
using System.IO;

namespace BigEndian.IOTests
{
    public class BigEndianBinaryWriterTests
    {
        MemoryStream stream;
        BinaryReader litteEndianReader;
        BigEndianBinaryWriter bigEndianWriter;

        [SetUp]
        public void Setup()
        {
            stream = new MemoryStream();
            litteEndianReader = new BinaryReader(stream);
            bigEndianWriter = new BigEndianBinaryWriter(stream);
        }

        [TearDown]
        public void Teardown()
        {
            stream.Dispose();
        }

        [Test]
        public void WriteBigEndianFloat_NotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => bigEndianWriter.WriteBigEndian((float)0));
        }

        [Test]
        public void WriteBigEndianDouble_NotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => bigEndianWriter.WriteBigEndian((double)0));
        }

        [Test]
        public void WriteBigEndianDecimal_NotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => bigEndianWriter.WriteBigEndian((decimal)0));
        }

        [TestCase(unchecked((short)0x0001), unchecked((short)0x0100))]
        [TestCase(unchecked((short)0x0100), unchecked((short)0x0001))]
        [TestCase(unchecked((short)0xfffe), unchecked((short)0xfeff))]
        public void WriteBigEndianShort_Succeeds(short littleEndian, short bigEndian)
        {
            bigEndianWriter.WriteBigEndian(littleEndian);
            stream.Position = 0;

            Assert.That(litteEndianReader.ReadInt16(), Is.EqualTo(bigEndian));
        }

        [TestCase(unchecked((ushort)0x0001), unchecked((ushort)0x0100))]
        [TestCase(unchecked((ushort)0x0100), unchecked((ushort)0x0001))]
        [TestCase(unchecked((ushort)0xfffe), unchecked((ushort)0xfeff))]
        public void WriteBigEndianUShort_Succeeds(ushort littleEndian, ushort bigEndian)
        {
            bigEndianWriter.WriteBigEndian(littleEndian);
            stream.Position = 0;

            Assert.That(litteEndianReader.ReadUInt16(), Is.EqualTo(bigEndian));
        }

        [TestCase(unchecked((int)0x00000001), unchecked((int)0x01000000))]
        [TestCase(unchecked((int)0x00000100), unchecked((int)0x00010000))]
        [TestCase(unchecked((int)0xfffffffe), unchecked((int)0xfeffffff))]
        public void WriteBigEndianInt_Succeeds(int littleEndian, int bigEndian)
        {
            bigEndianWriter.WriteBigEndian(littleEndian);
            stream.Position = 0;

            Assert.That(litteEndianReader.ReadInt32(), Is.EqualTo(bigEndian));
        }

        [TestCase(unchecked((uint)0x00000001), unchecked((uint)0x01000000))]
        [TestCase(unchecked((uint)0x00000100), unchecked((uint)0x00010000))]
        [TestCase(unchecked((uint)0xfffffffe), unchecked((uint)0xfeffffff))]
        public void WriteBigEndianUInt_Succeeds(uint littleEndian, uint bigEndian)
        {
            bigEndianWriter.WriteBigEndian(littleEndian);
            stream.Position = 0;

            Assert.That(litteEndianReader.ReadUInt32(), Is.EqualTo(bigEndian));
        }

        [TestCase(unchecked((long)0x0000000000000001), unchecked((long)0x0100000000000000))]
        [TestCase(unchecked((long)0x0000000000000100), unchecked((long)0x0001000000000000))]
        [TestCase(unchecked((long)0xfffffffffffffffe), unchecked((long)0xfeffffffffffffff))]
        public void WriteBigEndianLong_Succeeds(long littleEndian, long bigEndian)
        {
            bigEndianWriter.WriteBigEndian(littleEndian);
            stream.Position = 0;

            Assert.That(litteEndianReader.ReadInt64(), Is.EqualTo(bigEndian));
        }

        [TestCase(unchecked((ulong)0x0000000000000001), unchecked((ulong)0x0100000000000000))]
        [TestCase(unchecked((ulong)0x0000000000000100), unchecked((ulong)0x0001000000000000))]
        [TestCase(unchecked((ulong)0xfffffffffffffffe), unchecked((ulong)0xfeffffffffffffff))]
        public void WriteBigEndianULong_Succeeds(ulong littleEndian, ulong bigEndian)
        {
            bigEndianWriter.WriteBigEndian(littleEndian);
            stream.Position = 0;

            Assert.That(litteEndianReader.ReadUInt64(), Is.EqualTo(bigEndian));
        }
    }
}