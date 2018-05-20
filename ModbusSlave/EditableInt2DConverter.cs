using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModbusSlave
{
    public class EditableInt2DConverter : IValueConverter
    {
        class ItemWrapper
        {
            int[,] container;
            int i, j;

            public ItemWrapper(int[,] container, int i, int j)
            {
                this.container = container;
                this.i = i;
                this.j = j;
            }

            public int Value
            {
                get => container[i, j];
                set => container[i, j] = value;
            }
        }

        public object Convert(object value, Type targetType, object p, CultureInfo ci)
        {
            var array2d = (int[,])value;
            var n = array2d.GetLength(0);
            var m = array2d.GetLength(1);
            ItemWrapper[,] items = new ItemWrapper[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    items[i, j] = new ItemWrapper(array2d, i, j);
            return items;
        }

        public object ConvertBack(object value, Type targetType, object p, CultureInfo ci) =>
            throw new NotSupportedException();
    }
}
