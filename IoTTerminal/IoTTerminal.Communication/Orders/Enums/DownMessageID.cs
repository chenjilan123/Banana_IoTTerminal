using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Orders
{
    public enum DownMessageID : ushort
    {
        //=============================== Down ==============================================
        PlatCommonResponse = 0x8001,
        RegisterResponse = 0x8100,
        SetTerminalParameter = 0x8103,
        SearchTerminalParameter = 0x8104,
        SearchSpecificTerminalParameter = 0x8106,

    }
}
