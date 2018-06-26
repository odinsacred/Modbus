using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModbusLib;

namespace ModbusLibTest
{
    [TestClass]
    public class MemoryMapTest
    {
        
        [TestMethod]
        public void SetInputRegisterTest()
        {
            UInt16 index = 0;
            UInt16 address = 1;
            MemoryMap map = new MemoryMap();
            map.AddInputRegister(new Register<ushort>(address) { Value = 100 });
            map.SetInputRegister(address, 100);
            UInt16 result = map.InputRegisters[index].Value;
            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void GetInputRegisterTest()
        {
            UInt16 index = 10;
            MemoryMap map = new MemoryMap();
            map.AddInputRegister(new Register<ushort>(index) { Value = 100 });
            map.SetInputRegister(index, 100);
            UInt16 result = map.GetInputRegister(index);
            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void SetHoldingRegisterTest()
        {
            UInt16 index = 0;
            UInt16 address = 3;
            MemoryMap map = new MemoryMap();
            map.AddHoldingRegister(new Register<ushort>(address) { Value = 100 });
            map.SetHoldingRegister(address, 100);
            UInt16 result = map.HoldingRegisters[index].Value;
            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void GetHoldingRegisterTest()
        {
            UInt16 index = 10;
            MemoryMap map = new MemoryMap();
            map.AddHoldingRegister(new Register<ushort>(index) { Value = 100 });
            map.SetHoldingRegister(index, 100);
            UInt16 result = map.GetHoldingRegister(index);
            Assert.AreEqual(result, 100);
        }

    }
} 