using ModbusSlave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.ViewModels
{
    public class DeviceViewModel : TreeNode
    {
        public bool[] IsWorking { get; set; } = { true, false };

        public int Address { get; set; } = 1;

        public bool IsWorkingSelected { get; set; }

        public DeviceViewModel(PortViewModel owner)
        {
            Owner = owner;
            type = NodeTypes.device;
            Name = "Device";
            Icon = "/Images/device.png";
        }

        public PortViewModel Owner { get; private set; }

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
