using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car
{
    public class JTB808Terminal : Terminal
    {
        #region Constructor
        public JTB808Terminal(string ip, int port, string platenum, string platecolor, string simnum)
            : base(ip, port, platenum, platecolor, simnum) { }
        #endregion
    }
}
