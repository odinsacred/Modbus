using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC8
{
    class Crc8MAXIM : IPolynomial
    {
        public byte Poly { get; set; }
        public byte Init { get; set; }
        public byte XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc8MAXIM()
        {
            Poly = 0x31;
            Init = 0x00;
            RefIn = true;
            RefOut = true;
            XorOut = 0x00;
        }
    }
}
