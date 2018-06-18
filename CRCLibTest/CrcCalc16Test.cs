using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRCLib;
using CRCLib.Poly;
using System.Text;

namespace CRCLibTest
{
    [TestClass]
    public class CrcCalc16Test
    {

        [TestMethod]
        public void CRC16CCITT_Test()
        {
            UInt16 expected = 0x29B1;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_CCITT);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16ARC_Test()
        {
            UInt16 expected = 0xBB3D;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_ARC);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16AUG_CCITT_Test()
        {
            UInt16 expected = 0xE5CC;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_AUG_CCITT);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16BUYPASS_Test()
        {
            UInt16 expected = 0xFEE8;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_BUYPASS);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16CDMA2000_Test()
        {
            UInt16 expected = 0x4C06;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_CDMA2000);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16DDS110_Test()
        {
            UInt16 expected = 0x9ECF;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_DDS110);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16DECTR_Test()
        {
            UInt16 expected = 0x007E;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_DECT_R);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16DECTX_Test()
        {
            UInt16 expected = 0x007F;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_DECT_X);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16DNP_Test()
        {
            UInt16 expected = 0xEA82;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_DNP);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16EN13757_Test()
        {
            UInt16 expected = 0xC2B7;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_EN13757);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16GENIBUS_Test()
        {
            UInt16 expected = 0xD64E;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_GENIBUS);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16MAXIM_Test()
        {
            UInt16 expected = 0x44C2;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_MAXIM);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16MCRF4XX_Test()
        {
            UInt16 expected = 0x6F91;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_MCRF4XX);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16RIELLO_Test()
        {
            UInt16 expected = 0x63D0;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_RIELLO);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16T10DIF_Test()
        {
            UInt16 expected = 0xD0DB;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_T10DIF);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16TELEDISK_Test()
        {
            UInt16 expected = 0x0FB3;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_TELEDISK);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16TMS37157_Test()
        {
            UInt16 expected = 0x26B1;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_TMS37157);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16USB_Test()
        {
            UInt16 expected = 0xB4C8;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_USB);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16A_Test()
        {
            UInt16 expected = 0xBF05;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_A);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16KERMIT_Test()
        {
            UInt16 expected = 0x2189;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_KERMIT);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16ModbusTest()
        {
            UInt16 expected = 0x4B37;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_MODBUS);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16X25_Test()
        {
            UInt16 expected = 0x906E;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_X25);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CRC16XMODEM_Test()
        {
            UInt16 expected = 0x31C3;
            string testString = "123456789";
            byte[] data = Encoding.ASCII.GetBytes(testString);//0xFA;
            UInt16 actual;
            CrcCalc16 crcCalc = new CrcCalc16(Polynomials.CRC16_XMODEM);
            actual = crcCalc.Checksum(data);
            Assert.AreEqual(expected, actual);
        }
    }
}
