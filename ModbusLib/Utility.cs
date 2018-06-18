using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public static class Utility
    {
        static UInt16 _lmask = 0x00FF;
        static UInt16 _hmask = 0xFF00;

        public static UInt16 ConvertLittleEndianToBigEndian(UInt16 value)
        {
            UInt16 temp = (UInt16)((value & _lmask) << 8);
            return (UInt16)(temp | ((value & _hmask) >> 8)); 
        }

        public static UInt16 ConvertBigEndianToLittleEndian(UInt16 value)
        {
            UInt16 temp = (UInt16)((value & _hmask) >> 8);
            return (UInt16)(temp | ((value & _lmask) << 8));
        }

        public static List<byte> GetBytesFromReg(UInt16 reg)
        {
            List<byte> array = new List<byte>();            
            array.Add((byte)(reg >> 8));
            array.Add((byte)(reg & _lmask));
            return array;
        } 
        public static UInt16 GetLittleEndian(byte high, byte low)
        {
            UInt16 temp = low;
            temp <<= 8;
            temp |= high;
            return temp;
        }

        public static UInt16 GetBigEndian(byte high, byte low)
        {
            UInt16 temp = high;
            temp <<= 8;
            temp |= low;
            return temp;
        }

        public static List<byte> ConvertListUInt16ToListByteBigEndian(List<UInt16> data)
        {
            List<byte> bytes = new List<byte>();
            foreach (UInt16 item in data)
            {               
                bytes.Add((byte)(item >> 8));
                bytes.Add((byte)(item & _lmask));
            }
            return bytes;
        }

        public static List<UInt16> ConvertListByteToListUint(List<byte> littleEndianData)
        {
            List<UInt16> values = new List<UInt16>();
            byte[] array = littleEndianData.ToArray();
            for (int i = 0; i < littleEndianData.Count; i = i+2)
            {
                values.Add(BitConverter.ToUInt16(array, i));
            }
            return values;
        }

        public static byte CreateExceptionFunctionCode(byte functionCode)
        {
            return (byte)(functionCode | 0x80); 
        }

        public static byte[] GetBigEndianByteArray(UInt16 value)
        {
            byte[] array = new byte[2];
            array[0] = (byte)(value >>8);
            array[1] = (byte)(value & _lmask);
            return array;
        }

        public static byte[] GetLittleEndianByteArray(UInt16 value)
        {
            byte[] array = new byte[2];
            array[1] = (byte)(value >> 8);
            array[0] = (byte)(value & _lmask);
            return array;
        }
    }
}
