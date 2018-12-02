using ModbusSlave.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.ViewModels
{
    public class PortViewModel : TreeNode
    {
        public bool[] IsWorking { get; set; } = { true, false };

        public int Ports { get; set; }

        public int[] Baud => new int[] { 9600, 19200, 115200, 921600 };

        public int[] DataBits => new[] { 8,7 }; 

        public int Parity { get; set; } //TODO: разобраться с типом Parity

        public int[] StopBits => new int[] { 1, 2 };

        #region selectedValues
        public bool IsWorkingSelected { get; set; }

        public int PortSelected { get; set; }

        public int BaudSelected { get; set; }

        public int DataBitsSelected { get; set; }

        public int ParitySelected { get; set; } //TODO: разобраться с типом Parity

        public int StopBitsSelected { get; set; }
        #endregion selectedValues

        //public event PropertyChangedEventHandler PropertyChanged;

        public PortViewModel(LocalHostViewModel owner)
        {
            Owner = owner;
            type = NodeTypes.port;
            Name = "Name PortGroupNode";
            Icon = "/Images/port.png";
        }
        public LocalHostViewModel Owner { get; private set; }

        bool isInEditMode = false;
        public bool IsInEditMode
        {
            get { return isInEditMode; }
            set
            {
                isInEditMode = value;
                NotifyPropertyChanged("IsInEditMode");
            }
        }
    }
}
