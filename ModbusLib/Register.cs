using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ModbusLib
{
    public class Register
    {
        public Register(int address)
        {
            Address = address;
        }

        public int Address { get; }
    }

    public class Register<T> : Register, INotifyPropertyChanged
    {
        public Register(int address) : base(address)
        {
        }

        public T Value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
