using ComportLib;
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

        public string[] Ports => SerialComm.GetAvailablePorts();

        public int[] Baud => new int[] { 9600, 19200, 115200, 921600 };

        public int[] DataBits => new[] { 8,7 };

        public ComPortLib.Parity[] Parity => new ComPortLib.Parity[]
                { ComPortLib.Parity.Even, ComPortLib.Parity.None,ComPortLib.Parity.Odd}; //TODO: разобраться с типом Parity

        public ComPortLib.StopBits[] StopBits => new ComPortLib.StopBits[] 
                { ComPortLib.StopBits.One, ComPortLib.StopBits.Two, ComPortLib.StopBits.None };

        #region selectedValues
        public bool IsWorkingSelected { get; set; }

        public string PortSelected { get; set; } = "COM1";

        public int BaudSelected { get; set; } = 19200;

        public int DataBitsSelected { get; set; } = 8;

        public ComPortLib.Parity ParitySelected { get; set; } = ComPortLib.Parity.None;//TODO: разобраться с типом Parity

        public ComPortLib.StopBits StopBitsSelected { get; set; } = ComPortLib.StopBits.One;
        #endregion selectedValues

        //public event PropertyChangedEventHandler PropertyChanged;

        public PortViewModel(LocalHostViewModel owner)
        {
            Owner = owner;
            type = NodeTypes.port;
            Name = "Port";
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

        public ICommunication GetPort()
        {
            return new SerialComm(PortSelected, BaudSelected, ParitySelected, DataBitsSelected, StopBitsSelected);
        }
    }
}
