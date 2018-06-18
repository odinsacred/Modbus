using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRCLib;
using System.Text;
using CRCLib.Poly;

namespace CRCLibTest
{
    [TestClass]
    public class CrcCalc8Test
    {
        [TestMethod]
        public void Crc8Usual_Test()
        {
            byte expected = 0xF4;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8CDMA2000_Test()
        {
            byte expected = 0xDA;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_CDMA2000);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8DARC_Test()
        {
            byte expected = 0x15;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_DARC);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8DVB_S2_Test()
        {
            byte expected = 0xBC;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_DVBS2);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8EBU_Test()
        {
            byte expected = 0x97;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_EBU);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8ICODE_Test()
        {
            byte expected = 0x7E;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_ICODE);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8ITU_Test()
        {
            byte expected = 0xA1;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_ITU);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8MAXIM_Test()
        {
            byte expected = 0xA1;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_MAXIM);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8ROHC_Test()
        {
            byte expected = 0xD0;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_ROHC);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Crc8WCDMA_Test()
        {
            byte expected = 0x25;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            byte actual;
            CrcCalc8 crcCalc = new CrcCalc8(Polynomials.CRC8_WCDMA);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

      
    }
}
