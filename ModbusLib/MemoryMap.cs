using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public class MemoryMap : IMemoryMap
    {
        private const int MEMORY_BLOCK_LENGTH = 65536;
        internal bool[] _discreteInputs;
        internal bool[] _coils;
        internal UInt16[] _inputRegisters;
        internal UInt16[] _holdingRegisters;

        public MemoryMap()
        {
            _discreteInputs = new bool[MEMORY_BLOCK_LENGTH];
            _coils = new bool[MEMORY_BLOCK_LENGTH];
            _inputRegisters = new UInt16[MEMORY_BLOCK_LENGTH];
            _holdingRegisters = new UInt16[MEMORY_BLOCK_LENGTH];
        }

        public bool GetDiscreteInput(uint index)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");

            return _discreteInputs[index];
        }

        public void SetDiscreteInput(uint index, bool value)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");

            _discreteInputs[index] = value;
        }

        public bool GetCoil(uint index)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");

            return _coils[index];
        }

        public void SetCoil(uint index, bool value)
        {
            if (index > MEMORY_BLOCK_LENGTH)
                throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");

            _coils[index] = value;
        }

        public UInt16 GetInputRegister(uint index)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");

            return _inputRegisters[index];
        }

        public void SetInputRegister(uint index, UInt16 value)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");

            _inputRegisters[index] = value;
        }

        public UInt16 GetHoldingRegister(uint index)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");

            return _holdingRegisters[index];
        }

        public void SetHoldingRegister(int index, UInt16 value)
        {
            _holdingRegisters[index] = value;
        }

        //-----------------------------------------------------------------

        public bool[] GetDiscreteInputs(uint index, uint count)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");
            if(count == 0)
                throw new ArgumentException("count == 0");
            if(index + count > MEMORY_BLOCK_LENGTH)
                throw new ArgumentOutOfRangeException("index + count > MEMORY_BLOCK_LENGTH");

            bool[] array = new bool[count];
            for (uint i = index, j = 0; i < count; i++, j++)
            {
                array[j] = _discreteInputs[i];
            }
            return array;
        }

        public bool[] GetCoils(uint index, uint count)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");
            if (count == 0)
                throw new ArgumentException("count == 0");
            if (index + count > MEMORY_BLOCK_LENGTH)
                throw new ArgumentOutOfRangeException("index + count > MEMORY_BLOCK_LENGTH");

            bool[] array = new bool[count];
            for (uint i = index, j = 0; i < count; i++, j++)
            {
                array[j] = _discreteInputs[i];
            }
            return array;
        }

        public UInt16[] GetInputRegisters(uint index, uint count)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");
            if (count == 0)
                throw new ArgumentException("count == 0");
            if (index + count > MEMORY_BLOCK_LENGTH)
                throw new ArgumentOutOfRangeException("index + count > MEMORY_BLOCK_LENGTH");

            UInt16[] array = new UInt16[count];
            for (uint i = index, j = 0; i < count; i++, j++)
            {
                array[j] = _inputRegisters[i];
            }
            return array;
        }

        public UInt16[] GetHoldingRegisters(uint index, uint count)
        {
            //if (index > MEMORY_BLOCK_LENGTH)
            //    throw new ArgumentOutOfRangeException("index > MEMORY_BLOCK_LENGTH");
            if (count == 0)
                throw new ArgumentException("count == 0");
            if (index + count > MEMORY_BLOCK_LENGTH)
                throw new ArgumentOutOfRangeException("index + count > MEMORY_BLOCK_LENGTH");

            UInt16[] array = new UInt16[count];
            for (uint i = index, j = 0; i < count; i++, j++)
            {
                array[j] = _holdingRegisters[i];
            }
            return array;
        }

    }
}
