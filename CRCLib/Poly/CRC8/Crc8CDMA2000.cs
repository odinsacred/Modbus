using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC8
{
    class Crc8CDMA2000 : IPolynomial
    {
        public byte Poly { get; set; }
        public byte Init { get; set; }
        public byte XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc8CDMA2000()
        {
            Poly = 0x9B;
            Init = 0xFF;
            RefIn = false;
            RefOut = false;
            XorOut = 0x00;
        }
    }
}
