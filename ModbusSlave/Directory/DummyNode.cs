﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ModbusSlave
{
    class DummyNode :INotifyPropertyChanged, INode
    {
        private string itemName;

        public event PropertyChangedEventHandler PropertyChanged;

        public NodeTypes type { get; set; }

        private ObservableCollection<INode> children;

        public ObservableCollection<INode> Children { get { return children; } set { children = value; } }

        public DummyNode()
        {
            type = NodeTypes.port;
            Children = new ObservableCollection<INode>();
            ItemName = "DUMMY";
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
                OnPropertyChanged(new PropertyChangedEventArgs("*"));
            }
        }
    }
}
