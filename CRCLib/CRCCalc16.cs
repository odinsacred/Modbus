using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRCLib.Poly;

namespace CRCLib
{
    public class CrcCalc16
    {
        IPolynomial16 poly;
        private UInt16[] table = new UInt16[256];

        public CrcCalc16(IPolynomial16 polynomial)
        {
            poly = polynomial;
            table = GenerateTable(poly);
        }

        public UInt16 Checksum(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("val");

            UInt16 crc = poly.Init;// 0;
            byte temp = 0;
            foreach (byte item in data)
            {
                temp = (byte)(crc ^ item);
                crc >>= 8;
                crc ^= table[temp];
            }
            crc ^= poly.XorOut;
            return crc;
        }

        private UInt16[] GenerateTable(IPolynomial16 polynomial)
        {
            UInt16[] csTable = new UInt16[256];
            for (UInt16 i = 0; i <= 255; i++)
            {
                csTable[i] = GetCRC(i, polynomial.Poly, polynomial.RefIn, polynomial.RefOut, polynomial.XorOut);
            }
            return csTable;
        }

        private UInt16 GetCRC(UInt16 data, UInt16 poly, bool refIn, bool refOut, UInt16 xorOut)
        {
            data <<= 8;
            if (refIn)
                data = BitReverse(data);

            for (byte i = 0; i < 16; i++)
            {
                
                if ((data & 0x8000) != 0)
                {
                    data = (UInt16)((data << 1) ^ (int)poly);
                }
                else
                {
                    data <<= 1;
                }
            }

            if (refOut)
                data = BitReverse(data);

            return data;
        }

     
        UInt16 BitReverse(UInt16 data)
        {
            UInt16 result = 0;
            UInt16 temp = 0;
            UInt16 mask = 0x0001;

            for (int i = 0; i < 16; i++)
            {
                result <<= 1;
                temp = (UInt16)(data & mask);
                result |= temp;
                data >>= 1;
            }
            return result;
        }

       
    }
}
