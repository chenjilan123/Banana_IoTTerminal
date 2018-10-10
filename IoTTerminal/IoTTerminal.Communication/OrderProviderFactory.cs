using IoTTerminal.Communication.Interface;
using IoTTerminal.Communication.Orders;
using IoTTerminal.Communication.SocketPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication
{
    public class OrderProviderFactory
    {
        public static IUpOrderProvider CreateOrderProvider(string simnum, string ip, int port, IDownOrderReceiver receiver)
        {
            //可改成DI模式，以后又别的协议可配。
            IUpOrderPacker packer = new UpOrderPacker(simnum);
            IDownOrderParser parser = new DownOrderParser(receiver);
            var client = new Client(ip, port, parser);
            return new JTB808OrderProvider(simnum, ip, port, parser, packer, client);
        }
    }
}
