using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ModbusSlave
{
    public class Cell
    {
        public int Value { get; set; }
        public Brush BackGroundColor { get; set; }
        public Color TextColor { get; set; }
        public bool Blink { get; set; }
    }
}
