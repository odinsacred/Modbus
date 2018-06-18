using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC8
{
    class Crc8ITU : IPolynomial
    {
        public byte Poly { get; set; }
        public byte Init { get; set; }
        public byte XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc8ITU()
        {
            Poly = 0x07;
            Init = 0x00;
            RefIn = false;
            RefOut = false;
            XorOut = 0x55;
        }
    }
}
