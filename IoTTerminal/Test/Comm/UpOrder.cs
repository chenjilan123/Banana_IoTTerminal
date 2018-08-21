using IoTTerminal.Communication.Orders;
using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Comm
{
    public class UpOrder
    {
        private UpOrderPacker packer = new UpOrderPacker("13100000001");
        private HexTransfer transfer = new HexTransfer();
        [Fact]
        public void Register_TEST()
        {
            var package = packer.Register(1234, 123, "1233121233", "12312312ABCDE", "AB10001", "鄂A55555", 2);
            var hexStr = transfer.GetHex(package);
        }
    }
}
