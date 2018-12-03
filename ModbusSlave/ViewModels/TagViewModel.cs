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
    public class TagViewModel : TreeNode
    {

        public bool[] IsWorking { get; set; } = { true, false };

        public bool Running { get; set; } = true;

        public int Value { get; set; }

        public DataTypes[] DataType => 
            new DataTypes[] {DataTypes.Int16, DataTypes.UInt16, DataTypes.Int32,
                                DataTypes.UInt32, DataTypes.Float, DataTypes.Double};
        public AccessModes[] AccessMode => 
            new AccessModes[] { AccessModes.ReadWrite, AccessModes.ReadOnly, AccessModes.WriteOnly };

        public int Address { get; set; } = 1;

        public bool IsWorkingSelected { get; set; }

        public DataTypes DatatypeSelected { get; set; } = DataTypes.UInt16;

        public AccessModes AccessModeSelected { get; set; }

        public Register GetRegister()
        {//TODO: Какая-то дичь получилась. Нужно выводить Value регистра в текстовое поле, хз как
            if (DatatypeSelected == DataTypes.UInt16)
                return new Register<UInt16>(Address);
            else
                throw new Exception("Не установлен тип данных для тега " + Name);
        } 

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
