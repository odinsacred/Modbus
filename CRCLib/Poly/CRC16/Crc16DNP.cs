using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC16
{
    class Crc16DNP : IPolynomial16
    {
        public UInt16 Poly { get; set; }
        public UInt16 Init { get; set; }
        public UInt16 XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc16DNP()
        {
            Poly = 0x3D65;
            Init = 0x0000;
            RefIn = true;
            RefOut = true;
            XorOut = 0xFFFF;
        }
    }
}
