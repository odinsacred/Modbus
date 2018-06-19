using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using ComportLib;
using System.Threading;
using CRCLib;
using CRCLib.Poly;

namespace ModbusLib
{
    public class Slave : IDisposable
    {
        
        UInt16 _address;
        IMemoryMap _memoryMap;
        ISerialPort _serialPort;
        CrcCalc16 _crcCalc;
        FunctionsImplementation _mbFunctions;
        public Slave(UInt16 address, ISerialPort serialPort,  IMemoryMap memoryMap, CancellationToken token)
        {
            _address = address;
            _memoryMap = memoryMap;
            _serialPort = serialPort;
            _crcCalc = new CrcCalc16(Polynomials.CRC16_MODBUS);
            _mbFunctions = new FunctionsImplementation(_memoryMap);
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
                    byte[] message = new byte[count];
                    for (int i = 0; i < count; i++)
                    {
                        message[i] = buffer[i];
                    }
                    await _serialPort.WriteBufferAsync(Parse(message), token);

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

        private byte[] Parse(byte[] message)
        {
            int count = message.Length;
            if (_crcCalc.Checksum(message) == 0)
            {
                if (message[0] != _address)
                    throw new Exception("Wrong Address in request");

                switch (message[1])
                {
                    case 0x03:
                        UInt16 startingAddress = Utility.ConvertBigEndianToLittleEndian(BitConverter.ToUInt16(message,2));
                        UInt16 numOfRegisters = Utility.ConvertBigEndianToLittleEndian(BitConverter.ToUInt16(message, 4));
                        return CreateResponse(_mbFunctions.FuncReadHoldingRegisters(startingAddress, (byte)numOfRegisters).ToArray());
                    case 0x06:
                        UInt16 registerAddress = Utility.ConvertBigEndianToLittleEndian(BitConverter.ToUInt16(message, 2));
                        UInt16 Value = Utility.ConvertBigEndianToLittleEndian(BitConverter.ToUInt16(message, 4));
                        return CreateResponse(_mbFunctions.FuncWriteSingleRegister(registerAddress, (byte)Value).ToArray());
                    default: return CreateResponse(_mbFunctions.FunctionCodeNotSupported().ToArray());
                }
            }
            else
            {
                throw new Exception("Invalid checksum");
            }
        }

        private byte[] CreateResponse(byte[] message)
        {
            List<byte> response = new List<byte>();
            
            response.Add((byte)_address);
            response.AddRange(message);

            UInt16 crc16 = _crcCalc.Checksum(response.ToArray());
            response.AddRange(Utility.GetLittleEndianByteArray(crc16));
            return response.ToArray();
        }
    }
}
