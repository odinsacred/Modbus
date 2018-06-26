using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ModbusSlave
{
    public class EditableInt2DConverter : IValueConverter
    {
        class ItemWrapper
        {
            Cell[,] container;
            int i, j;

            public ItemWrapper(Cell[,] container, int i, int j)
            {
                this.container = container;
                this.i = i;
                this.j = j;
            }

            public int Value
            {
                get => container[i, j].Value;
                set => UpdateData(value);//container[i, j].Value = value;
            }

            public Brush Color
            {
                get => container[i, j].BackGroundColor;
                set => container[i, j].BackGroundColor = value;
            }

            private void UpdateData(int value)
            {
                container[i, j].Value = value;
                
            }
        }

        public object Convert(object value, Type targetType, object p, CultureInfo ci)
        {
            var array2d = (Cell[,])value;
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
