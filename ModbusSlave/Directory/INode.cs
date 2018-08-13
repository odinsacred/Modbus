using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave
{
    interface INode
    {
        ObservableCollection<INode> Children { get; set; }
        NodeTypes type { get; set; }
    }
}
