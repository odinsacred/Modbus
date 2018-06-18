using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModbusLib;

namespace ModbusLibTest
{
    [TestClass]
    public class MemoryMapTest
    {
        [TestMethod]
        public void SetDiscreteInputTest()
        {
            UInt16 index = 1;
            MemoryMap map = new MemoryMap();
            map.SetDiscreteInput(index, true);
            bool result = map._discreteInputs[index];
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void GetDiscreteInputTest()
        {
            UInt16 index = 1;
            MemoryMap map = new MemoryMap();
            map.SetDiscreteInput(index, true);
            bool result = map.GetDiscreteInput(index);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void SetCoilTest()
        {
            UInt16 index = 1;
            MemoryMap map = new MemoryMap();
            map.SetCoil(index, true);
            bool result = map._coils[index];
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void GetCoilTest()
        {
            UInt16 index = 1;
            MemoryMap map = new MemoryMap();
            map.SetCoil(index, true);
            bool result = map.GetCoil(index);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void SetInputRegisterTest()
        {
            UInt16 index = 1;
            MemoryMap map = new MemoryMap();
            map.SetInputRegister(index, 100);
            UInt16 result = map._inputRegisters[index];
            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void GetInputRegisterTest()
        {
            UInt16 index = 1;
            MemoryMap map = new MemoryMap();
            map.SetInputRegister(index, 100);
            UInt16 result = map.GetInputRegister(index);
            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void SetHoldingRegisterTest()
        {
            UInt16 index = 1;
            MemoryMap map = new MemoryMap();
            map.SetHoldingRegister(index, 100);
            UInt16 result = map._holdingRegisters[index];
            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void GetHoldingRegisterTest()
        {
            UInt16 index = 1;
            MemoryMap map = new MemoryMap();
            map.SetHoldingRegister(index, 100);
            UInt16 result = map.GetHoldingRegister(index);
            Assert.AreEqual(result, 100);
        }

        //[TestMethod]
        //public void GetDiscreteInputsArgumentOutOfRangeExceptionTest()
        //{
        //    uint index = 65535;
        //    uint count = 10;
        //    MemoryMap map = new MemoryMap();
        //    map.GetDiscreteInputs(index, count);
        //    Assert.ThrowsException<ArgumentOutOfRangeException>(map.GetDiscreteInputs(index, count));
        //}




    }
} 