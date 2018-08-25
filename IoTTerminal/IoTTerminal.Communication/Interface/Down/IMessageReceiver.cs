using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Interface
{
    public interface IMessageReceiver
    {
        void ReceiveMessage(byte[] data);
    }
}
