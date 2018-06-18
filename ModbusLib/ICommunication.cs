using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public interface ICommunication
    {
        void Send(List<byte> message);
        List<byte> Recieve();
    }
}
