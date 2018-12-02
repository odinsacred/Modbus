using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ModbusSlave.Models
{
    public class PortNode : TreeNode
    {
        public PortNode(LocalHostNode owner)
        {
            Owner = owner;
            type = NodeTypes.port;
            Name = "Port";
            Icon = "/Images/DAGroup.png";
        }

        public LocalHostNode Owner { get; private set; }

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
