using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Comm
{
    public class DataTransfer
    {
        [Theory]
        [InlineData("0x7E91052145", new byte[] { 0x7e, 0x91, 0x05, 0x21, 0x45 })]
        public void HexTransfer_TEST(string input, byte[] data)
        {
            var transfer = new HexTransfer();
            var outData = transfer.GetBytes(input);
            Assert.Equal(data.Length, outData.Length);
            for (int i = 0; i < data.Length; i++)
                Assert.Equal(data[i], outData[i]);

            var outStr = transfer.GetHex(data);
            Assert.Equal(input.Replace("0x", "").ToUpper(), outStr.ToUpper());
        }
    }
}
