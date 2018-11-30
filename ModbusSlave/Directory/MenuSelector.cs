using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using ModbusSlave.Models;

namespace ModbusSlave
{
    public class MenuSelector : DataTemplateSelector
    {
        public DataTemplate DeviceTemplate { get; set; }
        public DataTemplate MasterTemplate { get; set; }
        public DataTemplate FolderTemplate { get; set; }
        public DataTemplate TagTemplate { get; set; }
        public DataTemplate PortTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            TreeNode node = (TreeNode)item;

            switch (node.type)
            {
                case NodeTypes.device:
                    return DeviceTemplate;
                case NodeTypes.folder:
                    return FolderTemplate;
                case NodeTypes.master:
                    return MasterTemplate;
                case NodeTypes.port:
                    return PortTemplate;
                case NodeTypes.tag:
                    return TagTemplate;
                default:
                    return null;
            }
        }
    }
}
