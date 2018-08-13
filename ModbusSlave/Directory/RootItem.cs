using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ModbusSlave
{
    class RootItem : INotifyPropertyChanged, INode
    {
        private string itemName;

        private ObservableCollection<INode> children;

        public ObservableCollection<INode> Children { get { return children; } set { children = value; } }

        public NodeTypes type { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RootItem()
        {
            type = NodeTypes.master;
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

        public void AddChild(PortItem child)
        {
            child.Parent = this;
            children.Add(child);
        }
    }
}
