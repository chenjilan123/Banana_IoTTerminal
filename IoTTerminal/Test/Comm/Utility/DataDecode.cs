using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Comm.Utility
{
    public class DataDecode
    {
        private DataDecoder decoder = new DataDecoder();

        [Theory]
        [InlineData("0030383233323331393237", "\00823231927")]
        public void DecodeToString(string input, string expect)
        {
            byte[] inputData = HexTransfer.GetBytesData(input);
            var inputStr = decoder.DecodeToString(inputData);

            Assert.Equal(expect, inputStr);
        }
    }
}
