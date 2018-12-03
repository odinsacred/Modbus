using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace ComportLib
{
    public class SerialComm : ICommunication
    {
        SerialPort _port;
        //Timer timer;
        //int timeout;
        //public event Action<byte[]> DataRecieved;
        public event Action PortClosedEvent;
        public event Action PortOpenedEvent;

        public SerialComm(string port, int baud, ComPortLib.Parity parity, int dataBits, ComPortLib.StopBits stopBits)
        {
            Open(port, baud, parity, dataBits, stopBits);
        }

        private void Open(string port, int baud, ComPortLib.Parity parity, int dataBits, ComPortLib.StopBits stopBits)//, int timeout)
        {
            _port = new SerialPort(port, baud, ConvertParity(parity), dataBits, ConvertStopBits(stopBits));
            _port.Open();
            if (PortOpenedEvent != null) PortOpenedEvent.Invoke();
        }

        public void Close()
        {
            if (_port.IsOpen)
            {
                _port.Close();
                //Dispose();
                if (PortClosedEvent != null) PortClosedEvent.Invoke();
            }
        }

        public static string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellation)
        {
            DisposedCheck();

            while (_port.BytesToRead <= 0)
                await Task.Delay(10, cancellation);
            return _port.Read(buffer, offset, count);
        }

        public async Task<int> ReadBytesAsync(byte[] buffer, CancellationToken cancellation)
        {
            DisposedCheck();
            // _port.DiscardInBuffer();
            while (_port.BytesToRead <= 0)
                await Task.Delay(10, cancellation);

            return _port.Read(buffer, 0, buffer.Length);
        }

        public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellation)
        {
            DisposedCheck();

            cancellation.ThrowIfCancellationRequested();

            _port.Write(buffer, offset, count);
            return Task.FromResult(0);
        }

        private void DisposedCheck()
        {
            if (_port == null)
                throw new ObjectDisposedException(nameof(SerialComm));
        }

        public void Dispose()
        {
            _port?.Dispose();
            _port = null;
        }

        private Parity ConvertParity(ComPortLib.Parity parity)
        {
            switch (parity)
            {
                case ComPortLib.Parity.None:
                    return Parity.None;
                case ComPortLib.Parity.Odd:
                    return Parity.Odd;
                case ComPortLib.Parity.Even:
                    return Parity.Even;
                default:
                    throw new Exception("Parity converter exception");
            }
        }

        private StopBits ConvertStopBits(ComPortLib.StopBits stopBits)
        {
            switch (stopBits)
            {
                case ComPortLib.StopBits.None:
                    return StopBits.None;
                case ComPortLib.StopBits.One:
                    return StopBits.One;
                case ComPortLib.StopBits.Two:
                    return StopBits.Two;
                default:
                    throw new Exception("StopBits converter exception");
            }
        }
    }
}
