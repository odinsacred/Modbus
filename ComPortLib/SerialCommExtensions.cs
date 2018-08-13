using System;
using System.Threading;
using System.Threading.Tasks;

namespace ComportLib
{
    public static class SerialCommExtensions
    {

        public static async Task<byte[]> ReadBufferAsync(this ICommunication serialPort, int count,
            CancellationToken cancellation)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var readedTotal = 0;
            var buffer = new byte[count];

            do
            {
                var readed = await serialPort.ReadAsync(buffer, readedTotal, count - readedTotal, cancellation);
                readedTotal += readed;
            } while (readedTotal < count);

            return buffer;
        }

        public static Task WriteBufferAsync(this ICommunication serialPort, byte[] buffer, CancellationToken cancellation)
        {
            return serialPort.WriteAsync(buffer, 0, buffer.Length, cancellation);
        }

    }
}
