using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public class FunctionsImplementation : IFunctions
    {
        const byte ERROR_CODE = 0x80;
        const byte QUANTITY_OF_REG_EXEPTION = 0x03;
        const byte FUNCTION_CODE_NOT_SUPPORTED = 0x1;
        const byte STARTING_ADDRESS_EXCEPTION = 0x2;
        const byte READ_MULTIPLE_REGISTERS_EXCEPTION = 0x4;
        const byte REGISTER_VALUE_EXEPTION = 0x03;

        IMemoryMap memoryMap;

        public FunctionsImplementation(IMemoryMap memory)
        {
            memoryMap = memory;
        }

        public List<byte> FuncReadHoldingRegisters(UInt16 startingAddress, byte numberOfRegisters)
        {
            List<UInt16> regs;
            List<byte> bytes;
            List<byte> response = new List<byte>();

            if (numberOfRegisters == 0 || numberOfRegisters > 125)
            {
                response.Add(0x03 + ERROR_CODE);
                response.Add(QUANTITY_OF_REG_EXEPTION);
                return response;
            }
             
            if(startingAddress + numberOfRegisters > 65535)
            {
                response.Add(0x03 + ERROR_CODE);
                response.Add(STARTING_ADDRESS_EXCEPTION);
                return response;
            }
            
            regs = memoryMap.GetHoldingRegisters(startingAddress, numberOfRegisters).ToList<UInt16>();
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

            memoryMap.SetHoldingRegister(registerAddress, value);
            data.Add(registerAddress);
            data.Add(value);
            bytes = Utility.ConvertListUInt16ToListByteBigEndian(data).ToList<byte>();
            response.Add(0x06);
            response.AddRange(bytes);
            return response;
        }

        public List<byte> FunctionCodeNotSupported(byte function)
        {
            List<byte> response = new List<byte>();
            response.Add((byte)(function + ERROR_CODE));
            response.Add(FUNCTION_CODE_NOT_SUPPORTED);
            return response;
        }

        
    }
}
