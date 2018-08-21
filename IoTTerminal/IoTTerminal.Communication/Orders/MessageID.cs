using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Orders
{
    public enum MessageID : ushort
    {
        //=============================== Up ================================================
        Register = 0x0100,


        //=============================== Down ==============================================
        RegisterResponse = 0x8100,
    }
}
