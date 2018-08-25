using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Comm.Utility
{
    public class DataEncode
    {
        private DataEncoder encoder = new DataEncoder();
        [Theory]
        [InlineData(20)]
        [InlineData(500)]
        public void EncodeShort(short input)
        {
            var output = encoder.Encode(input);

        }

        [Theory]
        [InlineData("1234567890", new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 })]
        public void EncodeBCD(string input, byte[] except)
        {
            var output = encoder.EncodeBCD(input, input.Length);

            for (int i = 0; i < except.Length; i++)
            {
                Assert.Equal(except[i], output[i]);
            }
        }

        [Theory]
        [InlineData("\00823231927", "0030383233323331393237")]
        public void EncodeString(string input, string expect)
        {
            byte[] expectData = HexTransfer.GetBytesData(expect);

            byte[] encodeStr = encoder.EncodeString(input);

            for (int i = 0; i < expectData.Length; i++)
            {
                Assert.Equal(expectData[i], encodeStr[i]);
            }
        }
    }
}
