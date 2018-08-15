using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car
{
    public class Terminal
    {
        #region Field
        private string ip;
        private int port;
        private string platenum;
        private string platecolor;
        private string simnum;
        #endregion

        #region Main Property
        public string IP
        {
            get { return ip; }
        }

        public int Port
        {
            get { return port; }
        }

        public string PlateNum
        {
            get { return platenum; }
        }

        public string PlateColor
        {
            get { return platecolor; }
        }

        public string SimNum
        {
            get { return simnum; }
        }

        #endregion

        #region Constructor
        public Terminal(string ip, int port, string platenum, string platecolor, string simnum)
        {
            this.ip = ip;
            this.port = port;
            this.platenum = platenum;
            this.platecolor = platecolor;
            this.simnum = simnum;
        }
        #endregion

        #region Base Orders

        #region Register

        #endregion

        #region Authentication

        #endregion

        #region Heartbeat

        #endregion

        #endregion
    }
}
