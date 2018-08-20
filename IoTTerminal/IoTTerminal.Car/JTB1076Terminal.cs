using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car
{
    public class JTB1076Terminal : JTB808Terminal
    {
        #region Constructor
        public JTB1076Terminal(string ip, int port, string platenum, byte platecolor, string simnum, string terminalID)
            : base(ip, port, platenum, platecolor, simnum, terminalID) { }
        #endregion
    }
}
