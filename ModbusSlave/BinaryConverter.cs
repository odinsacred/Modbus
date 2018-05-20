using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModbusSlave
{
    public class BinaryConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = System.Convert.ToString(System.Convert.ToInt32(System.Convert.ToDouble(value)), 2);
            int missedNulls = 16 - val.Length;
            for (int i = 0; i < missedNulls; i++)
            {
                val = "0" + val;
            }
            return val;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int32 val = ConvertBinToInt(System.Convert.ToString(value));
            return val;
        }

        private Int32 ConvertBinToInt(string value)
        {
            Int32 result = 0;

            for (int i = 0; i < value.Length; i++)
            {
                int val = Int32.Parse(value[value.Length-i-1].ToString());
                int pow = ((int)Math.Pow(2, i));
                result = result + ( val * pow);
            }
            return result;
        }
    }
}
