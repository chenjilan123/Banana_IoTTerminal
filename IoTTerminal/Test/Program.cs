using IoTTerminal.Car;
using IoTTerminal.Communication.SocketPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static void Main()
        {
            JTB808Terminal terminal = new JTB808Terminal("218.5.10.82", 21005, "鄂A56789", 2, "13800000001", "A100001");
            terminal.Register();

            Console.ReadLine();
        }


        #region StartListen
        private static void StartListen()
        {
            var taskLst = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                var task = ListenTask();
                taskLst.Add(task);
                task.Start();

                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }

        private static Task ListenTask()
        {
            return new Task(ListenToServer);
        }

        private static void ListenToServer()
        {
            AutoResetEvent allDone = new AutoResetEvent(false);
            IPHostEntry hostInfo = Dns.GetHostEntry(Dns.GetHostName());//.NET Core AddressList的第一个元素为InterNetworkV6
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
        }
        #endregion
    }
}
