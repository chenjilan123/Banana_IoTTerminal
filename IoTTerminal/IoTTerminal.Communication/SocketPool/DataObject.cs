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
    }
}
