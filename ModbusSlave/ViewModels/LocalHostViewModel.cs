using Caliburn.Micro;
using ModbusSlave.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.ViewModels
{
    public class LocalHostViewModel : TreeNode
    {
        public LocalHostViewModel(ServersTree owner)
        {
            Owner = owner;
            Name = "localhost";
            type = NodeTypes.master;
            IsExpanded = true;
            Icon = "/Images/database-off.png";
        }

        public ServersTree Owner { get; private set; }

    }
}
