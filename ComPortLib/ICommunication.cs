using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace ComportLib
{
    public interface ICommunication : IDisposable

    {
        event Action PortClosedEvent;
        event Action PortOpenedEvent;

        void Close();
        Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellation);
        Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellation);
        Task<int> ReadBytesAsync(byte[] buffer, CancellationToken cancellation);

    }
}
