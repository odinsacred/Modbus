using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using ComportLib;
using System.Threading;

namespace ModbusLib
{
    public class Slave : IDisposable
    {
        UInt16 _address;
        IMemoryMap _memoryMap;
        ISerialPort _serialPort;
        //string portName, int baud, Parity parity, int dataBits, StopBits stopBits

        public Slave(UInt16 address, ISerialPort serialPort,  IMemoryMap memoryMap, CancellationToken token)
        {
            _address = address;
            _memoryMap = memoryMap;
            _serialPort = serialPort;
            Run(token);
        }

        public void Dispose()
        {
            Stop();
        }

        private async void Run(CancellationToken token)
        {
            int count = 0;
            byte[] buffer;// = new byte[256];
            while (!token.IsCancellationRequested)
            {
                try
                {
                    buffer = new byte[256];
                    count = await _serialPort.ReadBytesAsync(buffer, token);
                    byte crcLo = buffer[count - 2];
                    byte crcHi = buffer[count - 1];
                }
                catch (Exception ex)
                {
                    
                }
                

            }
            _serialPort.Close();
            _serialPort.Dispose();
        }

        private void Stop()
        {

        }

        private void Parse(int count, byte[] buffer)
        {
            List<byte> message = new List<byte>();
            for (int i = 0; i < count; i++)
            {
                if (buffer[i] == _address)
                    message.Add(buffer[i]);
            }
        }

    }
}
