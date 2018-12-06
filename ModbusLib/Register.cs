using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ModbusLib
{
    public class Register:INotifyPropertyChanged
    {
        private UInt16 _value;

        public Register(int address)
        {
            Address = address;
        }

        public int Address { get; }

        public UInt16 Value {
            get
            {
                return _value;
            }
            set
            { _value = value;
                NotifyPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }

    //public class Register<T> : Register, INotifyPropertyChanged
    //{
    //    public Register(int address) : base(address)
    //    {
    //    }

    //    public T Value { get; set; }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //}
}
