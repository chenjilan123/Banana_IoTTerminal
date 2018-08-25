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
        private const string simnum = "13100000001";
        private UpOrderPacker packer = new UpOrderPacker(simnum);
        private HexTransfer transfer = new HexTransfer();
        [Fact]
        public void Register_TEST()
        {
            var package = packer.Register(1234, 123, "1233121233", "12312312ABCDE", "AB10001", "鄂A55555", 2, out ushort orderID);
            var hexStr = transfer.GetHex(package);
        }

        [Theory]
        [InlineData(1234, 4222, 0, "7E00010006013100000001XXXX04D2107D0200VV7E")] //include 7E(messageID 4222)
        public void TerminalCommonResponse_TEST(ushort orderID, ushort messageID, byte result, string expect)
        {
            var package = packer.TerminalCommonResponse(orderID, messageID, result, out ushort headerOrderID);
            var resultStr = transfer.GetHex(package);

            ThrowExceptionIfOrderStringNotEqual(expect, resultStr);
        }


        private void ThrowExceptionIfOrderStringNotEqual(string expect, string actual)
        {
            var orderIDIndex = expect.IndexOf("XXXX");
            var orderID = actual.Substring(orderIDIndex, 4);
            expect = expect.Replace("XXXX", orderID);

            var dataStrWithoutCheckCode = expect.Substring(2, expect.Length - 6);
            var dataWithoutCheckCode = transfer.GetBytes(dataStrWithoutCheckCode);
            byte checkCode = 0x00;
            foreach (var dataItem in dataWithoutCheckCode)
                checkCode ^= dataItem;
            expect = expect.Replace("VV", checkCode.ToString("X2"));

            Assert.Equal(expect, actual);
        }
    }
}
