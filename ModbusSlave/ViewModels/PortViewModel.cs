using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.ViewModels
{
    public class PortViewModel : INotifyPropertyChanged
    {
        public bool IsWorking { get; set; }

        public int Port { get; set; }

        public int Baud { get; set; }

        public int DataBits { get; set; }

        public int Parity { get; set; } //TODO: разобраться с типом Parity

        public int StopBits { get; set; }

        
        public event PropertyChangedEventHandler PropertyChanged;

        public void Refreshed()
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(string.Empty));
        }

    }
}
