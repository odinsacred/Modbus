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

        List<Tag> Tags { get; set; } = new List<Tag>();
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
            this.memoryMap.HoldingRegisterChanged += MemoryMap_HoldingRegisterChanged;
        }

        private void MemoryMap_HoldingRegisterChanged(ushort address, ushort value)
        {
            foreach (var item in Tags)
            {
                if (item.Value.Address == address)
                    item.Value.Value = value;
            }
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
            foreach (var item in Children)
            {
                TagViewModel tag = (TagViewModel)item;
                Tags.Add(tag);
                memoryMap.AddHoldingRegister(tag.Value);          
            }
            return memoryMap;
        }
    }
}
