using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Utinity
{
    public class DataEncoder
    {
        private static Encoding gb2312Encoding = Encoding.GetEncoding("gb2312");
        private byte[] ReverseToBigEndian(byte[] data)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return data;
        }
        public byte[] Encode(int input)
        {
            return ReverseToBigEndian(BitConverter.GetBytes(input));
        }
        public byte[] Encode(long input)
        {
            return ReverseToBigEndian(BitConverter.GetBytes(input));
        }
        public byte[] Encode(uint input)
        {
            return ReverseToBigEndian(BitConverter.GetBytes(input));
        }
        public byte[] Encode(ushort input)
        {
            return ReverseToBigEndian(BitConverter.GetBytes(input));
        }
        public byte[] Encode(short input)
        {
            return ReverseToBigEndian(BitConverter.GetBytes(input));
        }
        public byte[] Encode(string input, int length, bool padLeft = false)
        {
            if (input.Length > length)
                input = input.Substring(0, length);
            else if (input.Length < length)
                input = padLeft ? input.PadLeft(length, '0') : input.PadRight(length, '\0');
            return Encoding.ASCII.GetBytes(input);
        }
        public byte[] EncodeString(string input)
        {
            return gb2312Encoding.GetBytes(input);
        }

        public byte[] EncodeBCD(string simnum, int length)
        {
            if (simnum.Length > length)
                simnum = simnum.Substring(0, length);
            else if (simnum.Length < length)
                simnum = simnum.PadLeft(length, '0');
            var outData = new byte[length / 2];
            for (int i = 0; i < outData.Length ; i++)
                outData[i] = Convert.ToByte(simnum.Substring(i * 2, 2), 16);
            return outData;
        }
    }
}
