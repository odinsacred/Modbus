using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public interface IObserver
    {
        void Update(UInt16 value);
    }
}
