using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ModbusLib;

namespace ModbusLibTest
{
    [TestClass]
    public class FunctionImplementationTest
    {


        [TestMethod]
        public void FuncReadHoldingRegistersFunctionCodeTest()
        {
            byte expected = 0x03;
            MemoryMap memory = new MemoryMap();
            memory.SetHoldingRegister(0,0xAABB);
            memory.SetHoldingRegister(1, 0xCCDD);
            FunctionsImplementation imp = new FunctionsImplementation(memory);
            List<byte> response = imp.FuncReadHoldingRegisters(1,2);
            Assert.AreEqual(expected, response[0]);
        }

        [TestMethod]
        public void FuncReadHoldingRegistersByteCountTest()
        {
            byte expected = 0x04;
            MemoryMap memory = new MemoryMap();
            memory.SetHoldingRegister(0, 0xAABB);
            memory.SetHoldingRegister(1, 0xCCDD);
            FunctionsImplementation imp = new FunctionsImplementation(memory);
            List<byte> response = imp.FuncReadHoldingRegisters(1, 2);
            Assert.AreEqual(expected, response[1]);
        }

        [TestMethod]
        public void FuncReadHoldingRegistersDataTest()
        {
            List<byte> expected = new List<byte>();
            expected.Add(0xAA);
            expected.Add(0xBB);
            expected.Add(0xCC);
            expected.Add(0xDD);
            MemoryMap memory = new MemoryMap();
            memory.SetHoldingRegister(0, 0xAABB);
            memory.SetHoldingRegister(1, 0xCCDD);
            FunctionsImplementation imp = new FunctionsImplementation(memory);
            List<byte> response = imp.FuncReadHoldingRegisters(0, 2);
            for (int i = 2; i < response.Count; i++)
            {
                Assert.AreEqual(expected[i-2], response[i]);
            }            
        }

        [TestMethod]
        public void FuncWriteSingleRegisterResponseTest()
        {
            List<byte> expected = new List<byte>();
            expected.Add(0x06);
            expected.Add(0x00);
            expected.Add(0x00);
            expected.Add(0xAA);
            expected.Add(0xBB);
            MemoryMap memory = new MemoryMap();
            FunctionsImplementation imp = new FunctionsImplementation(memory);
            List<byte> response = imp.FuncWriteSingleRegister(0, 0xAABB);
            for (int i = 0; i < response.Count; i++)
            {
                Assert.AreEqual(expected[i], response[i]);
            }
            
        }

        [TestMethod]
        public void FuncWriteSingleRegisterTest()
        {
            UInt16 index = 0;
            UInt16 register = 0;
            List<byte> expected = new List<byte>();
            List<byte> writedValue = new List<byte>();
            expected.Add(0xAA);
            expected.Add(0xBB);
            MemoryMap memory = new MemoryMap();
            FunctionsImplementation imp = new FunctionsImplementation(memory);
            imp.FuncWriteSingleRegister(index, 0xAABB);
            register = memory.GetHoldingRegister(0);
            writedValue.AddRange(Utility.GetBytesFromReg(register));
            Assert.AreEqual(expected[0], writedValue[0]);
            Assert.AreEqual(expected[1], writedValue[1]);
        }

        [TestMethod]
        public void ReadWriteRegTest()
        {
            byte func = 0x03;
            byte byteCount = 0x04;
            byte reg1ValHi = 0xAA;
            byte reg1ValLo = 0xBB;
            byte reg2ValHi = 0xCC;
            byte reg2ValLo = 0xDD;

            List<byte> response;
            List<byte> expected = new List<byte>();
            expected.Add(func);
            expected.Add(byteCount);
            expected.Add(reg1ValHi);
            expected.Add(reg1ValLo);
            expected.Add(reg2ValHi);
            expected.Add(reg2ValLo);

            MemoryMap memory = new MemoryMap();
            FunctionsImplementation imp = new FunctionsImplementation(memory);
            imp.FuncWriteSingleRegister(0, 0xAABB);
            imp.FuncWriteSingleRegister(1, 0xCCDD);
            response = imp.FuncReadHoldingRegisters(0, 2);
            for (int i = 0; i < response.Count; i++)
            {
                Assert.AreEqual(expected[i], response[i]);
            }
        }
    }
}
