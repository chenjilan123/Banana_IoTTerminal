using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car
{
    public abstract class Vehicle
    {
        #region Field
        protected string ip;
        protected int port;
        protected string platenum;
        protected byte platecolor;
        protected string simnum;
        protected string terminalID;
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

        public byte PlateColor
        {
            get { return platecolor; }
        }

        public string SimNum
        {
            get { return simnum; }
        }
        #endregion

        #region Constructor
        public Vehicle(string ip, int port, string platenum, byte platecolor, string simnum, string terminalID)
        {
            this.ip = ip;
            this.port = port;
            this.platenum = platenum;
            this.platecolor = platecolor;
            this.simnum = simnum;
            this.terminalID = terminalID;
        }
        #endregion
    }
}
