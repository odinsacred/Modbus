using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly.CRC16
{
    public class Crc16Modbus : IPolynomial16
    {
        public UInt16 Poly { get; set; }
        public UInt16 Init { get; set; }
        public UInt16 XorOut { get; set; }
        public bool RefIn { get; set; }
        public bool RefOut { get; set; }

        public Crc16Modbus()
        {
            Poly = 0x8005;
            Init = 0xFFFF;
            RefIn = true;
            RefOut = true;
            XorOut = 0x0000;
        }
    }
}
