using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Utinity
{
    public class DataDecoder
    {
        private static Encoding gb2312Encoding = Encoding.GetEncoding("gb2312");
        public uint DecodeToUint(byte[] data, int startIndex)
        {
            var dest = new byte[4];
            Array.Copy(data, startIndex, dest, 0, dest.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(dest);
            return BitConverter.ToUInt32(dest, startIndex);
        }
        public ushort DecodeToUshort(byte[] data, int startIndex = 0)
        {
            var dest = new byte[2];
            Array.Copy(data, startIndex, dest, 0, dest.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(dest);
            return BitConverter.ToUInt16(dest, 0);
        }
        public string DecodeBCD(byte[] data)
        {
            var sb = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("X2"));
            return sb.ToString();
        }
        public string DecodeToString(byte[] data)
        {
            return gb2312Encoding.GetString(data);
        }
    }
}
