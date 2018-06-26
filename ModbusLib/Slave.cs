using System;
using System.Collections.Generic;
using ComportLib;
using System.Threading;
using CRCLib;
using CRCLib.Poly;

namespace ModbusLib
{
    public class Slave
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
                    List<byte> message = new List<byte>();
                    for (int i = 0; i < count; i++)
                    {
                        message.Add(buffer[i]);
                    }
                    await _serialPort.WriteBufferAsync(Parse(message.ToArray()), token);

                }
                catch (Exception ex)
                {
                    
                }
                

            }
            _serialPort.Close();
            _serialPort.Dispose();
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
                        return CreateResponse(_mbFunctions.FuncReadHoldingRegisters(startingAddress, (byte)numOfRegisters));
                    case 0x06:
                        UInt16 registerAddress = Utility.ConvertBigEndianToLittleEndian(BitConverter.ToUInt16(message, 2));
                        UInt16 Value = Utility.ConvertBigEndianToLittleEndian(BitConverter.ToUInt16(message, 4));
                        return CreateResponse(_mbFunctions.FuncWriteSingleRegister(registerAddress, (byte)Value));
                    default: return CreateResponse(_mbFunctions.FunctionCodeNotSupported(message[1]));
                }
            }
            else
            {
                throw new Exception("Invalid checksum");
            }
        }

        private byte[] CreateResponse(List<byte> message)
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
