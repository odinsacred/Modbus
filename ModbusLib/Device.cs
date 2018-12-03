using System;
using System.Collections.Generic;
using System.Linq;

namespace ModbusLib
{
    public class Device : IMemoryMap
    {
        internal List<Register<UInt16>> HoldingRegisters { get; } = new List<Register<UInt16>>();
        internal List<Register<UInt16>> InputRegisters { get; } = new List<Register<UInt16>>();

        public UInt16 HoldingRegsCount { get; set; }
        public UInt16 InputRegsCount { get; set; }

        public Device()
        {
            HoldingRegsCount = 0;
            InputRegsCount = 0;
        }

        public void AddHoldingRegister(Register<UInt16> register)
        {
            HoldingRegisters.Add(register);
            HoldingRegsCount = (UInt16)HoldingRegisters.Count;
        }

        public void SetHoldingRegister(UInt16 address, UInt16 value)
        {
            int index = HoldingRegisters.FindIndex(x => x.Address == address);
            HoldingRegisters[index].Value = value;
        }

        public UInt16 GetHoldingRegister(UInt16 address)
        {
            var finded = HoldingRegisters.Find(x => x.Address == address);

            return finded.Value;
        }

        public void AddInputRegister(Register<UInt16> register)
        {
            InputRegisters.Add(register);
            InputRegsCount = (UInt16)InputRegisters.Count;
        }

        public void SetInputRegister(UInt16 address, UInt16 value)
        {

            int index = InputRegisters.FindIndex(x => x.Address == address);
            InputRegisters[index].Value = value;
        }

        public UInt16 GetInputRegister(UInt16 address)
        {
            var finded = InputRegisters.Find(x => x.Address == address);
            return finded.Value;
        }



        //-----------------------------------------------------------------

        public UInt16[] GetInputRegisters(UInt16 index, UInt16 count)
        {
            if (count == 0)
                throw new ArgumentException("count == 0");
            if (index + count > InputRegisters.Count)
                throw new ArgumentOutOfRangeException("index + count out of range");

            var selected = from item in InputRegisters
                           where item.Address <= count
                           select item.Value;
            return selected.ToArray<UInt16>();
        }

        public UInt16[] GetHoldingRegisters(UInt16 address, UInt16 count)
        {
            if (count == 0)
                throw new ArgumentException("count == 0");

            var selected = from item in HoldingRegisters
                           where item.Address >= address && item.Address < address + count
                           select item.Value;
            return selected.ToArray<UInt16>();
        }

    }

   
    public class MemoryChangedEventArgs : EventArgs
    {
        public MemoryChangedEventArgs(int address)
        {
            Address = (ushort)address;
        }

        public uint Address { get; set; }
    }
}
