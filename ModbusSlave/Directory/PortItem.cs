using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace ModbusSlave
{
    class PortItem : INotifyPropertyChanged, INode
    {
        private string name;

        private int baud;

        private ObservableCollection<INode> children;

        public ObservableCollection<INode> Children { get { return children; } set { children = value; } }


        public RootItem Parent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NodeTypes type { get; set; }

        public PortItem()
        {
            type = NodeTypes.port;
            Children = new ObservableCollection<INode>();
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);

        }

        public string ItemName
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PortName"));
            }
        }

        public int Baud
        {
            get { return baud; }
            set
            {
                baud = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PortName"));
            }
        }

        public void AddChild(DeviceItem child)
        {
            child.Parent = this;
            children.Add(child);
        }
    }
}
