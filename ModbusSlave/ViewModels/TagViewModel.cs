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

        public List<Register> RawValue { get; set; }

        public DataTypes[] DataType => 
            new DataTypes[] {DataTypes.Int16, DataTypes.UInt16, DataTypes.Int32,
                                DataTypes.UInt32, DataTypes.Float, DataTypes.Double};
        public AccessModes[] AccessMode => 
            new AccessModes[] { AccessModes.ReadWrite, AccessModes.ReadOnly, AccessModes.WriteOnly };

        public int Address { get; set; } = 1;

        public bool IsWorkingSelected { get; set; }

        public DataTypes DatatypeSelected { get; set; } = DataTypes.UInt16;

        public AccessModes AccessModeSelected { get; set; }

        public DeviceViewModel Owner { get; private set; }

        public TagViewModel(DeviceViewModel owner)
        {
            Owner = owner;
            type = NodeTypes.tag;
            Name = "Tag";
            Icon = "/Images/right arrow.png";
            CreateReg();
        }

        bool isInEditMode = false;

        public string Value
        {
            get { return GetValue(); }
            set { RawValue[0].Value = UInt16.Parse(value); }
            
        }

        public bool IsInEditMode
        {
            get { return isInEditMode; }
            set
            {
                isInEditMode = value;
                NotifyPropertyChanged("IsInEditMode");
            }
        }

        public void ChangeValue(object o)
        {
            try
            {
                RawValue[0].Value = UInt16.Parse((string)o);
            }
            catch
            {

            }
            
        }

        public void RefreshDataType()
        {
            CreateReg();
        }

        public void RefreshAddress()
        {
            CreateReg();
        }

        private void CreateReg()
        {
            switch (DatatypeSelected)
            {
                case DataTypes.Int16: CreateReg(1); break;
                case DataTypes.UInt16: CreateReg(1); break;
                case DataTypes.Int32: CreateReg(2); break;
                case DataTypes.UInt32: CreateReg(2); break;
                case DataTypes.Float: CreateReg(2); break;
                case DataTypes.Double: CreateReg(4); break;

            }
        }

        private void CreateReg(int length)
        {
            RawValue = new List<Register>();
            for (int i = Address; i < Address+length; i++)
            {
                RawValue.Add(new Register(i));
            }            
        }

        private string GetValue()
        {
            switch (DatatypeSelected)
            {
                case DataTypes.Int16: return GetInt16Value().ToString();
                case DataTypes.UInt16: return GetUInt16Value().ToString();
            }
            return string.Empty;
        }
        private UInt16 GetUInt16Value()
        {
            return RawValue[0].Value;
        }

        private Int16 GetInt16Value()
        {
            return (Int16)RawValue[0].Value;
        }

    }
}
