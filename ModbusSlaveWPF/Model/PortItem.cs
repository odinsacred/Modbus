using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlaveWPF.Model
{
    class PortItem : INotifyPropertyChanged, INode
    {
        private string itemName;

        private ObservableCollection<INode> children;

        public ObservableCollection<INode> Children { get { return children; } set { children = value; } }

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
            get { return itemName; }
            set
            {
                itemName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ItemName"));
            }
        }

    }
}
