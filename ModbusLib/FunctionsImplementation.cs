using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public class FunctionsImplementation : IFunctions
    {
        MemoryMap map;

        public FunctionsImplementation(MemoryMap memory)
        {
            map = memory;
        }

        public List<byte> FuncReadHoldingRegisters(UInt16 startingAddress, byte numberOfRegisters)
        {
            List<UInt16> regs;
            List<byte> bytes;
            List<byte> response = new List<byte>();

            if (numberOfRegisters == 0 || numberOfRegisters > 125)
                throw new ArgumentOutOfRangeException("numberOfRegisters must be from 1 to 125");
            
            regs = map.GetHoldingRegisters(startingAddress, numberOfRegisters).ToList<UInt16>();
            bytes = Utility.ConvertListUInt16ToListByteBigEndian(regs).ToList<byte>();
            
            byte byteCount = (byte)(numberOfRegisters * 2);
            response.Add(0x03);
            response.Add(byteCount);
            response.AddRange(bytes);
            return response;
        }

        public List<byte> FuncWriteSingleRegister(UInt16 registerAddress, UInt16 value)
        {
            List<byte> bytes;
            List<UInt16> data = new List<UInt16>();
            List<byte> response = new List<byte>();

            map.SetHoldingRegister(registerAddress, value);
            data.Add(registerAddress);
            data.Add(value);
            bytes = Utility.ConvertListUInt16ToListByteBigEndian(data).ToList<byte>();
            response.Add(0x06);
            response.AddRange(bytes);
            return response;
        }
    }
}
