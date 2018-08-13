using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ModbusSlave
{
    [ValueConversion(typeof(INode), typeof(ContextMenu))]
    public class ItemToContextMenuConverter : IValueConverter
    {
        public static ContextMenu MasterContextMenu;
        public static ContextMenu PortContextMenu;
        public static ContextMenu DeviceContextMenu;
        public static ContextMenu DirContextMenu;

        public ItemToContextMenuConverter()
        {
            MasterContextMenu = new ContextMenu();
            MasterContextMenu.Items.Add("Text");
            MasterContextMenu.Items.Add("Text2");
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            INode item = value as INode;
            if (item == null) return null;

            if(item.type == NodeTypes.master)
                return  MasterContextMenu;
            if (item.type == NodeTypes.port)
                return PortContextMenu;

            return DeviceContextMenu;   
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
