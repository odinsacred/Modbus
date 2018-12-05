using ModbusLib;
using ModbusSlave.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.ViewModels
{
    public class DeviceViewModel : TreeNode
    {
        IMemoryMap memoryMap;

        public bool[] IsWorking { get; set; } = { true, false };

        public ushort Address { get; set; } = 1;

        public bool IsWorkingSelected { get; set; }

        public DeviceViewModel(PortViewModel owner, IMemoryMap memoryMap)
        {
            Owner = owner;
            type = NodeTypes.device;
            Name = "Device";
            Icon = "/Images/device.png";
            this.memoryMap = memoryMap;
        }

        public PortViewModel Owner { get; private set; }
        //public ObservableCollection<TagViewModel> Children { get; set; }
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

        public void Test()
        {
            GetMemory();
        }

        public IMemoryMap GetMemory()
        {
            Debug.WriteLine("GetMemory Method (memory map): " + memoryMap.GetHashCode());
            foreach (var item in Children)
            {
                TagViewModel tag = (TagViewModel)item;
                Debug.WriteLine("DeviceViewModel GetMemory Method (TagViewModel): " + tag.GetHashCode());
                foreach (Register reg in tag.RawValue)
                {
                    memoryMap.AddHoldingRegister(reg);                   
                }              
            }
            return memoryMap;
        }
    }
}
