using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public interface IFunctions
    {
        /// <summary>
        /// Function 0x01 Read coils from 1 to 2000
        /// </summary>
        /// <param name="startingAddress">0x0000 - 0xFFFF</param>
        /// <param name="quantityOfCoils">1 - 2000</param>
        /// <returns> Coil statuses</returns>
        //List<byte> FuncReadCoils(uint startingAddress, uint quantityOfCoils);

        /// <summary>
        /// Function 0x03 Read holding registers
        /// </summary>
        /// <param name="startingAddress">0x0000 - 0xFFFF</param>
        /// <param name="numberOfRegisters">1 to 125</param>
        /// <returns></returns>
        List<byte> FuncReadHoldingRegisters(UInt16 startingAddress, byte numberOfRegisters);
        List<byte> FuncWriteSingleRegister(UInt16 registerAddress, UInt16 value);
    }
}
