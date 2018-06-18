using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC8
{
    class Crc8ICODE : IPolynomial
    {
        public byte Poly { get; set; }
        public byte Init { get; set; }
        public byte XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc8ICODE()
        {
            Poly = 0x1D;
            Init = 0xFD;
            RefIn = false;
            RefOut = false;
            XorOut = 0x00;
        }
    }
}
