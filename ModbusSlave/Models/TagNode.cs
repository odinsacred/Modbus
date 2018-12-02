using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.Models
{
    public class TagNode : TreeNode
    {
        public TagNode(DeviceNode owner)
        {
            Owner = owner;
            type = NodeTypes.tag;
            Name = "Name TagNode";
            Icon = "/Images/DAGroup.png";
            //DetailsView = new TreeNodeDetailsView
            //{
            //    Page = new Uri("NodeView.xaml", UriKind.Relative),
            //    Data = null,//Items,
            //};
        }

        public DeviceNode Owner { get; private set; }
    }
}
