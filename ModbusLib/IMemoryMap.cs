using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public interface IMemoryMap
    {
        bool GetDiscreteInput(uint index);
        void SetDiscreteInput(uint index, bool value);
        bool GetCoil(uint index);
        void SetCoil(uint index, bool value);
        UInt16 GetInputRegister(uint index);
        void SetInputRegister(uint index, UInt16 value);
        UInt16 GetHoldingRegister(uint index);
        void SetHoldingRegister(int index, UInt16 value);
        bool[] GetDiscreteInputs(uint index, uint count);
        bool[] GetCoils(uint index, uint count);
        UInt16[] GetInputRegisters(uint index, uint count);
        UInt16[] GetHoldingRegisters(uint index, uint count);
    }
}
