using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.SocketPool
{
    /// <summary>
    /// Listenter
    /// Send data bytes and receive data bytes.
    /// There aren't any entities or value is allow to process in this object packaging.
    /// Only byte arrays should be input or output.
    /// </summary>
    public class Listener
    {
        private readonly Socket socket = null;
        private readonly string ip;
        private readonly int port;
        private readonly DataObject dataObject;
        public Listener(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.ip = ip;
            this.port = port;
            this.dataObject = new DataObject();
        }

        public async Task ConnectAsync()
        {
            if (!socket.Connected)
            {
                await socket.ConnectAsync(ip, port);
                await ReceiveTask();
            }
        }
        public async Task SendAsync(byte[] data)
        {
            var segment = new ArraySegment<byte>(data);
            await socket.SendAsync(segment, SocketFlags.None);
        }

        public async Task ReceiveTask()
        {
            var receiveSegment = new ArraySegment<byte>();
            while(true)
            {
                if (!socket.Connected)
                    break;
                var count = await socket.ReceiveAsync(receiveSegment, SocketFlags.None);
                if (count > 0)
                {
                    ReceiveData(receiveSegment.Array);
                }
            }
        }

        private void ReceiveData(byte[] data)
        {
            if (dataObject.isContainData)
            {

            }
            else
            {

            }
        }
    }
}
