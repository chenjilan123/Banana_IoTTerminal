using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Orders
{
    public enum UpMessageID : ushort
    {
        //=============================== Up ================================================
        TerminalCommonResponse = 0x0001,
        Heartbeat = 0x0002,
        Logout = 0x0003,
        Register = 0x0100,
        Authentication = 0x0102,
    }
}
