using IoTTerminal.Communication.Interface;
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
    public class DownOrder : IDownOrderReceiver
    {
        private DownOrderParser parser;
        public DownOrder()
        {
            parser = new DownOrderParser(this);
        }

        #region Interface
        public void PlatCommonResponse(ushort responseOrderID, byte result)
        {
            throw new NotImplementedException();
        }

        public void RegisterResponse(ushort responseOrderID, byte result, string authentication)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Test
        [Theory]
        [InlineData("7E8100000D013100000000F1D8028100303832333133333834381A7E")]
        public void RegisterResponse_TEST(string dataStr)
        {
            var data = HexTransfer.GetBytesData(dataStr);
            parser.ReceiveMessage(data);
        }
        #endregion

    }
}
