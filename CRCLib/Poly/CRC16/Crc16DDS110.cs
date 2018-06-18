using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC16
{
    class Crc16DDS110 : IPolynomial16
    {
        public UInt16 Poly { get; set; }
        public UInt16 Init { get; set; }
        public UInt16 XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc16DDS110()
        {
            Poly = 0x8005;
            Init = 0x800D;
            RefIn = false;
            RefOut = false;
            XorOut = 0x0000;
        }
    }
}
