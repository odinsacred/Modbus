using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlaveWPF.Model
{
    public interface INode
    {
        ObservableCollection<INode> Children { get; set; }
        string ItemName { get; set; }
        NodeTypes type { get; set; }
    }
}
