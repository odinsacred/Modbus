using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using ModbusLib;

namespace ModbusSlave.Models
{
    public class Tag : TreeNode
    {
        public int Address { get;  set; }
        public List<Register> RawValue { get; private set; }

        Register _value;
        public Register Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }

        //public Tag(int address, int length)
        //{
        //    Address = address;
        //    for (int i = address; i < address + length; i++)
        //    {
        //        Value.Add(new Register(i));
        //    }

        //}
        //protected int GetSizeOfValue(T value)
        //{
        //    return Marshal.SizeOf(value) / 2;
        //}
        //public virtual void AddValue(T value)
        //{
        //    int count = Marshal.SizeOf(value) / 2;
        //    for (int i = Address; i < Address + count; i++)
        //    {
        //        RawValue.Add(new Register(i));
        //    }
        //}
    }
}
