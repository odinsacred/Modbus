using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC16
{
    class Crc16CCITT : IPolynomial16
    {
        public UInt16 Poly { get; set; }
        public UInt16 Init { get; set; }
        public UInt16 XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc16CCITT()
        {
            Poly = 0x1021;
            Init = 0xFFFF;
            RefIn = false;
            RefOut = false;
            XorOut = 0x0000;
        }
    }
}
