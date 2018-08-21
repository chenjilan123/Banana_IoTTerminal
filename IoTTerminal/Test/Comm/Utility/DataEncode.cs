using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Comm
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
        [InlineData("1234567890", new byte[] { 0x90, 0x78, 0x56, 0x34, 0x12 })]
        public void EncodeBCD(string input, byte[] except)
        {
            var output = encoder.EncodeBCD(input, input.Length);

            for (int i = 0; i < except.Length; i++)
            {
                Assert.Equal(except[i], output[i]);
            }
        }
    }
}
