using IoTTerminal.Communication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication
{
    public class OrderProviderFactory
    {
        public static IUpOrderSender CreateOrderProvider(string simnum, string ip, int port, IDownOrderReceiver provider)
        {
            //可改成DI模式，以后又别的协议可配。
            return new JTB808OrderProvider(simnum, ip, port, provider);
        }
    }
}
