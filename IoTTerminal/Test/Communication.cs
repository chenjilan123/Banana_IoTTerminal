using IoTTerminal.Communication.SocketPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class Communication
    {
        [Fact]
        public async void Socket_TEST()
        {
            AutoResetEvent allDone = new AutoResetEvent(false);
            IPHostEntry hostInfo = Dns.Resolve(Dns.GetHostName());//.NET Core AddressList的第一个元素为InterNetworkV6
            IPAddress ipAddress = null;
            foreach (var address in hostInfo.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = address;
                    break;
                }
            }
            var client = new Client(ipAddress.ToString(), 9099);
            try
            {
                client.Connect();
                allDone.WaitOne();
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                e += "1";
            }

            //byte[] data = new byte[] { 1, 2, 3, 4, 5, 6 };
            //await client.SendAsync(data);
        }
    }
}
