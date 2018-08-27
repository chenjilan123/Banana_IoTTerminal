using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Video
{
    public class Mpeg4InH264
    {
        private const int bufferLength = 1024;
        public static async void Load()
        {
            var data = new byte[200 * bufferLength];
            var total = 0l;
            using (var stream = new FileStream($".\\Src\\Taylor Swift-Style.mp4", FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[bufferLength];
                var cnt = await stream.ReadAsync(buffer, 0, buffer.Length);
                while(cnt > 0 && total < data.Length)
                {
                    Array.Copy(buffer, 0, data, total, buffer.Length);
                    total += cnt;
                    cnt = await stream.ReadAsync(buffer, 0, buffer.Length);
                }
            }
            var str = HexTransfer.GetHexStr(data);
            str = str.Replace("000001", "X000001");
            var strArray = str.Split('X');
            Console.WriteLine($"     Count: {strArray.Length}");
            Console.WriteLine($"Avg Length: {str.Length / strArray.Length}");
            foreach (var s in strArray)
                Console.WriteLine(s.Substring(0, s.Length < 100 ? s.Length : 100));
        }
    }
}
