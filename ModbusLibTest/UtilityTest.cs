using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ModbusLib;

namespace ModbusLibTest
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void ConvertLittleEndianToBigEndianTest()
        {
            UInt16 littleEndianValue = 0xAABB;
            UInt16 BigEndianValue = 0xBBAA;
            UInt16 result = Utility.ConvertLittleEndianToBigEndian(littleEndianValue);
            Assert.AreEqual(BigEndianValue, result);
        }

        [TestMethod]
        public void ConvertBigEndianToLittleEndianTest()
        {
            UInt16 littleEndianValue = 0xAABB;
            UInt16 BigEndianValue = 0xBBAA;
            UInt16 result = Utility.ConvertBigEndianToLittleEndian(BigEndianValue);
            Assert.AreEqual(littleEndianValue, result);
        }

        [TestMethod]
        public void GetBytesFromRegTest()
        {
            UInt16 reg = 0xAABB;
            List<byte> expected = new List<byte>();
            expected.Add(0xAA);
            expected.Add(0xBB);
            List<byte> result = Utility.GetBytesFromReg(reg);
            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
        }
        [TestMethod]
        public void GetLittleEndinTest()
        {
            byte hByte = 0xAA;
            byte lByte = 0xBB;
            UInt16 littleEndianValue = 0xBBAA;
            UInt16 result = Utility.GetLittleEndian(hByte, lByte);
            Assert.AreEqual(littleEndianValue, result);
        }

        [TestMethod]
        public void GetBigEndinTest()
        {
            byte hByte = 0xAA;
            byte lByte = 0xBB;
            UInt16 littleEndianValue = 0xAABB;
            UInt16 result = Utility.GetBigEndian(hByte, lByte);
            Assert.AreEqual(littleEndianValue, result);
        }

        [TestMethod]
        public void ConvertListUInt16ToListByteTest()
        {
            List<UInt16> list = new List<UInt16>();
            List<byte> result = new List<byte>();
            List<byte> expected = new List<byte>();
            list.Add(0xAABB);
            list.Add(0xCCDD);
            expected.Add(0xAA);
            expected.Add(0xBB);
            expected.Add(0xCC);
            expected.Add(0xDD);
            result = Utility.ConvertListUInt16ToListByteBigEndian(list);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual<byte>(expected[i], result[i]);
            }
            
        }

        [TestMethod]
        public void ConvertListByteToListUintTest()
        {
            
            List<byte> list = new List<byte>();
            List<UInt16> result = new List<UInt16>();
            List<UInt16> expected = new List<UInt16>();
            list.Add(0xAA);
            list.Add(0xBB);
            expected.Add(0xBBAA);
            result = Utility.ConvertListByteToListUint(list);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual<UInt16>(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void CreateExceptionFunctionCodeTest()
        {
            byte functionCode = 0x03;
            byte expected = 0x83;
            byte result = Utility.CreateExceptionFunctionCode(functionCode);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetBigEndianByteArrayTest()
        {
            UInt16 value = 0xAABB;
            byte[] result;
            byte[] expected = new byte[2];
            expected[0] = 0xAA;
            expected[1] = 0xBB;
            result = Utility.GetBigEndianByteArray(value);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }            
        }

        [TestMethod]
        public void GetLittleEndianByteArrayTest()
        {
            UInt16 value = 0xAABB;
            byte[] result;
            byte[] expected = new byte[2];
            expected[0] = 0xBB;
            expected[1] = 0xAA;
            result = Utility.GetLittleEndianByteArray(value);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
