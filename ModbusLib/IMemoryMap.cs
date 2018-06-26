using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public interface IMemoryMap
    {
        UInt16 HoldingRegsCount { get; set; }
        UInt16 InputRegsCount { get; set; }

        UInt16 GetInputRegister(UInt16 index);
        void SetInputRegister(UInt16 index, UInt16 value);
        UInt16 GetHoldingRegister(UInt16 register);
        void SetHoldingRegister(UInt16 index, UInt16 value);
        UInt16[] GetInputRegisters(UInt16 index, UInt16 count);
        UInt16[] GetHoldingRegisters(UInt16 index, UInt16 count);

        void AddHoldingRegister(Register<UInt16> register);
    }
}
