using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.SocketPool
{
    /// <summary>
    /// Listenter
    /// Send data bytes and receive data bytes.
    /// There aren't any entities or value is allow to process in this object packaging.
    /// Only byte arrays should be input or output.
    /// 
    /// The performance must be optimizing.
    /// </summary>
    public class Client
    {
        private readonly Socket socket = null;
        private readonly string ip;
        private readonly int port;
        private readonly DataObject dataObject;
        public Client(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.ip = ip;
            this.port = port;
            this.dataObject = new DataObject();
        }

        public void Connect()
        {
            if (!socket.Connected)
            {
                socket.Connect(ip, port);
                var receiveTask = new Task(ReceiveTask);
                receiveTask.Start();
            }
        }
        public async void SendAsync(byte[] data)
        {
            var segment = new ArraySegment<byte>(data);
            await socket.SendAsync(segment, SocketFlags.None);
        }

        public async void ReceiveTask()
        {
            var receiveSegment = new ArraySegment<byte>(new byte[1024]);
            while (true)
            {
                var count = await socket.ReceiveAsync(receiveSegment, SocketFlags.None);
                if (count > 0)
                {
                    dataObject.PushData(receiveSegment.Array, count);
                }
            }
        }
    }
}
