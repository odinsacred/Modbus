using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRCLib.Poly.CRC8;
using CRCLib.Poly.CRC16;

namespace CRCLib.Poly
{
    public class Polynomials
    {
        public static IPolynomial CRC8 { get; set; }
        public static IPolynomial CRC8_CDMA2000 { get; set; }
        public static IPolynomial CRC8_DARC { get; set; }
        public static IPolynomial CRC8_DVBS2 { get; set; }
        public static IPolynomial CRC8_EBU { get; set; }
        public static IPolynomial CRC8_ICODE { get; set; }
        public static IPolynomial CRC8_ITU { get; set; }
        public static IPolynomial CRC8_MAXIM { get; set; }
        public static IPolynomial CRC8_ROHC { get; set; }
        public static IPolynomial CRC8_WCDMA { get; set; }

        public static IPolynomial16 CRC16_CCITT { get; set; }
        public static IPolynomial16 CRC16_ARC { get; set; }
        public static IPolynomial16 CRC16_AUG_CCITT { get; set; }
        public static IPolynomial16 CRC16_BUYPASS { get; set; }
        public static IPolynomial16 CRC16_CDMA2000 { get; set; }
        public static IPolynomial16 CRC16_DDS110 { get; set; }
        public static IPolynomial16 CRC16_DECT_R { get; set; }
        public static IPolynomial16 CRC16_DECT_X { get; set; }
        public static IPolynomial16 CRC16_DNP { get; set; }
        public static IPolynomial16 CRC16_EN13757 { get; set; }
        public static IPolynomial16 CRC16_GENIBUS { get; set; }
        public static IPolynomial16 CRC16_MAXIM { get; set; }
        public static IPolynomial16 CRC16_MCRF4XX { get; set; }
        public static IPolynomial16 CRC16_RIELLO { get; set; }
        public static IPolynomial16 CRC16_T10DIF { get; set; }
        public static IPolynomial16 CRC16_TELEDISK { get; set; }
        public static IPolynomial16 CRC16_TMS37157 { get; set; }
        public static IPolynomial16 CRC16_USB { get; set; }
        public static IPolynomial16 CRC16_A { get; set; }
        public static IPolynomial16 CRC16_KERMIT { get; set; }
        public static IPolynomial16 CRC16_MODBUS { get; set; }
        public static IPolynomial16 CRC16_X25 { get; set; }
        public static IPolynomial16 CRC16_XMODEM { get; set; }
        static Polynomials()
        {
            CRC8 = new Crc8Usual();
            CRC8_CDMA2000 = new Crc8CDMA2000();
            CRC8_DARC = new Crc8DARC();
            CRC8_DVBS2 = new Crc8DVBS2();
            CRC8_EBU = new Crc8EBU();
            CRC8_ICODE = new Crc8ICODE();
            CRC8_ITU = new Crc8ITU();
            CRC8_MAXIM = new Crc8MAXIM();
            CRC8_ROHC = new Crc8ROHC();
            CRC8_WCDMA = new Crc8WCDMA();

            CRC16_CCITT = new Crc16CCITT();
            CRC16_ARC = new Crc16ARC();
            CRC16_AUG_CCITT = new Crc16AugCCITT();
            CRC16_BUYPASS = new Crc16BUYPASS();
            CRC16_CDMA2000 = new Crc16CDMA2000();
            CRC16_DDS110 = new Crc16DDS110();
            CRC16_DECT_R = new Crc16DECT_R();
            CRC16_DECT_X = new Crc16DECT_X();
            CRC16_DNP = new Crc16DNP();
            CRC16_EN13757 = new Crc16EN13757();
            CRC16_GENIBUS = new Crc16GENIBUS();
            CRC16_MAXIM = new Crc16Maxim();
            CRC16_MCRF4XX = new Crc16MCRF4XX();
            CRC16_RIELLO = new Crc16RIELLO();
            CRC16_T10DIF = new Crc16T10DIF();
            CRC16_TELEDISK = new Crc16Teledisk();
            CRC16_TMS37157 = new Crc16TMS37157();
            CRC16_USB = new Crc16USB();
            CRC16_A = new Crc16A();
            CRC16_KERMIT = new Crc16KERMIT();
            CRC16_MODBUS = new Crc16Modbus();
            CRC16_X25 = new Crc16X25();
            CRC16_XMODEM = new Crc16Xmodem();
        }
    }
}
