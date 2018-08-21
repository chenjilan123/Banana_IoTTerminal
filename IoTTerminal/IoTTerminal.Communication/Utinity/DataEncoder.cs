using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Utinity
{
    public class DataEncoder
    {
        internal byte[] Encode(int input)
        {
            return BitConverter.IsLittleEndian ? BitConverter.GetBytes(input).Reverse().ToArray() : BitConverter.GetBytes(input);
        }
        internal byte[] Encode(long input)
        {
            return BitConverter.IsLittleEndian ? BitConverter.GetBytes(input).Reverse().ToArray() : BitConverter.GetBytes(input);
        }
        internal byte[] Encode(string input)
        {
            return null;
        }

    }
}
