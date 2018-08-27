using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Utinity
{
    public class HexTransfer
    {
        public static string GetHexStr(byte[] data)
        {
            return GetHexStr(data, data.Length);
            //var sb = new StringBuilder(data.Length * 2);
            //foreach (var b in data)
            //    sb.Append(b.ToString("X2"));
            //return sb.ToString();
        }
        public static string GetHexStr(byte[] data, int length)
        {
            var sb = new StringBuilder(length * 2);
            for(int i = 0; i < length; i++)
                sb.Append(data[i].ToString("X2"));
            return sb.ToString();
        }

        public static byte[] GetBytesData(string str)
        {
            str = str.Replace("0x", "");
            byte[] data = new byte[str.Length / 2];
            for (int i = 0; i < data.Length; i++)
                data[i] = byte.Parse(str.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            return data;
        }
        public string GetHex(byte[] data)
        {
            var sb = new StringBuilder(data.Length * 2);
            foreach (var b in data)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        public byte[] GetBytes(string str)
        {
            str = str.Replace("0x", "");
            byte[] data = new byte[str.Length / 2];
            for (int i = 0; i < data.Length; i++)
                data[i] = byte.Parse(str.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            return data;
        }
    }
}
