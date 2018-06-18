using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ModbusLib;

namespace FunctionImplementationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FunctionsImplementation imp = new FunctionsImplementation(new MemoryMap());
            List<UInt16> values = new List<UInt16>();
            List<byte> byteValues = new List<byte>();
            values.Add(0xAABB);
            byteValues = imp.GetBytes(values);
            Assert.AreEqual(0xBB, byteValues[0]);
            Assert.AreEqual(0xAA, byteValues[1]);
        }
    }
}
