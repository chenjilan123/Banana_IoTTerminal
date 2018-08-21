using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.SocketPool
{
    public class DataObject
    {
        public List<byte> dataLst = new List<byte>();
        public bool isContainData
        {
            get
            {
                return dataLst.Count > 0;
            }
        }

        public void PushData(byte[] data, int count)
        {
            var receiveData = new byte[count];
            Array.Copy(data, 0, receiveData, 0, count);


            //======================== Test Area ======================================


            HexTransfer trans = new HexTransfer();
            var hexStr = trans.GetHex(receiveData);

            //=========================================================================
        }
    }
}
