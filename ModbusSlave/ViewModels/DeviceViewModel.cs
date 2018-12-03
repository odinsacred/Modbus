using ModbusLib;
using ModbusSlave.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            foreach (var item in Children)
            {
                TagViewModel tag = (TagViewModel)item;
                if (tag.DatatypeSelected == DataTypes.UInt16)
                    memoryMap.AddHoldingRegister((Register<ushort>)tag.GetRegister());//new Register<ushort>(tag.Address));

            }
            return memoryMap;
        }
    }
}
