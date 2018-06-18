using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public class ResponseF3
    {
        public byte FunctionCode { get; private set; }
        public byte ByteCount { get; private set; }
        public List<byte> Data { get; private set; }

        public ResponseF3(byte func, byte byteCount, List<byte> data)
        {
            FunctionCode = func;
            ByteCount = byteCount;
            Data = data.ToList<byte>();
        }

    }
}
