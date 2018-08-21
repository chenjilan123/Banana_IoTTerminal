using IoTTerminal.Communication;
using IoTTerminal.Communication.Interface;
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
        public JTB808Terminal(string ip, int port, string platenum, byte platecolor, string simnum, string terminalID)
            : base(ip, port, platenum, platecolor, simnum, terminalID)
        {
            iOrderProvider = OrderProviderFactory.CreateOrderProvider(simnum, ip, port);
        }
        #endregion

        #region Base Orders

        #region Register
        public void Register()
        {
            iOrderProvider.Register(0, 0, "12321", "132", this.terminalID, this.platenum, this.platecolor);
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
