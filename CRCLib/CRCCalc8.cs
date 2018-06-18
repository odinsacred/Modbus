using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRCLib.Poly;

namespace CRCLib
{
    public class CrcCalc8
    {
        IPolynomial poly;
        private byte[] table = new byte[255];

        public CrcCalc8(IPolynomial polynomial)
        {
            poly = polynomial;
            table = GenerateTable(poly);
        }

        public byte Checksum(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("val");

            byte init = poly.Init;// 0;
            byte temp = 0;
            foreach (byte item in data)
            {
                temp = (byte)(init ^ item);
                init >>= 8;
                init ^= table[temp];
            }
            init ^= poly.XorOut;
            return init;
        }

        private byte[] GenerateTable(IPolynomial polynomial)
        {
            byte[] csTable = new byte[255];
            for (byte i = 0; i < 255; i++)
            {
                csTable[i] = GetCRC(i, polynomial.Poly, polynomial.RefIn, polynomial.RefOut,polynomial.XorOut);
            }
            return csTable;
        }

        private byte GetCRC(byte data, byte poly, bool refIn, bool refOut, byte xorOut)
        {
            if(refIn)
                data = BitReverse(data);
            
            for (int i = 0; i < 8; i++)
            {
                if ((data & 0x80) != 0)
                {
                    data = (byte)((data << 1) ^ (int)poly);
                }
                else
                {
                    data <<= 1;
                }
            }
            if(refOut)
                data = BitReverse(data);
            return data;
        }

        byte BitReverse(byte data)
        {
            byte result = 0;
            byte temp = 0;
            byte mask = 0x01;

            for (int i = 0; i < 8; i++)
            {
                result <<= 1;
                temp = (byte)(data & mask);
                result |= temp;
                data >>= 1;
            }
            return result;
        }
    }
}
