using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public class Tag
    {
        public int Address { get; private set; }
        public List<Register> Value { get; private set; }

        public Tag(int address, int length)
        {
            Address = address;
            for (int i = address; i < address + length; i++)
            {
                Value.Add(new Register(i));
            }
            
        }
    }
}
