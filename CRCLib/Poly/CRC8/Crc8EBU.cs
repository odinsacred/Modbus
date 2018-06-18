using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC8
{
    class Crc8EBU : IPolynomial
    {
        public byte Poly { get; set; }
        public byte Init { get; set; }
        public byte XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc8EBU()
        {
            Poly = 0x1D;
            Init = 0xFF;
            RefIn = true;
            RefOut = true;
            XorOut = 0x00;
        }
    }
}
