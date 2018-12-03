using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortLib
{
    public enum StopBits
    {
        //
        // Summary:
        //     No stop bits are used. This value is not supported by the System.IO.Ports.SerialPort.StopBits
        //     property.
        None = 0,
        //
        // Summary:
        //     One stop bit is used.
        One = 1,
        //
        // Summary:
        //     Two stop bits are used.
        Two = 2,

    }
}
