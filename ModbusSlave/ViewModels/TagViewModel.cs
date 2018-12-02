using ModbusSlave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.ViewModels
{
    public class TagViewModel : TreeNode
    {
        public bool[] IsWorking { get; set; } = { true, false };

        public DataTypes[] DataType => 
            new DataTypes[] {DataTypes.Int16, DataTypes.UInt16, DataTypes.Int32,
                                DataTypes.UInt32, DataTypes.Float, DataTypes.Double};
        public AccessModes[] AccessMode => 
            new AccessModes[] { AccessModes.ReadWrite, AccessModes.ReadOnly, AccessModes.WriteOnly };

        public int Address { get; set; } = 1;

        public bool IsWorkingSelected { get; set; }

        public DataTypes DatatypeSelected { get; set; }

        public AccessModes AccessModeSelected { get; set; }

        public TagViewModel(DeviceViewModel owner)
        {
            Owner = owner;
            type = NodeTypes.tag;
            Name = "Tag";
            Icon = "/Images/right arrow.png";
        }

        public DeviceViewModel Owner { get; private set; }

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
