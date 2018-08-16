using IoTTerminal.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car
{
    public class JTB808Terminal : Vehicle
    {
        private readonly IOrderProvider iOrderProvider;
        #region Constructor
        public JTB808Terminal(string ip, int port, string platenum, string platecolor, string simnum)
            : base(ip, port, platenum, platecolor, simnum)
        {
            iOrderProvider = new JTB808OrderProvider(simnum);
        }
        #endregion

        #region Base Orders

        #region Register
        public void Register()
        {
            iOrderProvider.Register(this.platenum, this.platecolor, this.ip, this.port);
        }
        #endregion

        #region Authentication
        public void Authentication()
        {

        }
        #endregion

        #region Heartbeat
        public void Heartbeat()
        {

        }
        #endregion

        #region Position
        public void Position()
        {

        }
        #endregion

        #endregion
    }
}
