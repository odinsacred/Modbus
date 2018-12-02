using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.Models
{
    public class DeviceNode : TreeNode
    {
        public DeviceNode(PortNode owner)
        {
            Owner = owner;
            type = NodeTypes.device;
            Name = "Name DeviceNode";
            Icon = "/Images/DAGroup.png";
            //DetailsView = new TreeNodeDetailsView
            //{
            //    Page = new Uri("NodeView.xaml", UriKind.Relative),
            //    Data = null,//Items,
            //};
        }

        public PortNode Owner { get; private set; }
    }
}
