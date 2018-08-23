using IoTTerminal.Communication;
using IoTTerminal.Communication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car
{
    public class JTB808Terminal : Vehicle, IDownOrderReceiver
    {
        #region Field
        private readonly IUpOrderSender iOrderProvider;
        private bool isRegisted = false;
        private bool isAuthenticated = false;
        private string authenticationCode = string.Empty;
        #endregion

        #region Property
        public bool IsRegisted => isRegisted;

        public bool IsAuthenticated => isAuthenticated;
        #endregion

        #region Constructor
        public JTB808Terminal(string ip, int port, string platenum, byte platecolor, string simnum, string terminalID)
            : base(ip, port, platenum, platecolor, simnum, terminalID)
        {
            iOrderProvider = OrderProviderFactory.CreateOrderProvider(simnum, ip, port, this);
        }
        #endregion

        #region Sender

        #region Register
        public void Register()
        {
            iOrderProvider.Register(0, 0, "12321", "132", this.terminalID, this.platenum, this.platecolor);
        }
        #endregion

        #region Authentication
        public void Authentication()
        {
            iOrderProvider.Authentication(authenticationCode);
        }
        #endregion

        #region Heartbeat
        public void Heartbeat()
        {
            iOrderProvider.Heartbeat();
        }
        #endregion

        #region Position
        public void Position()
        {

        }
        #endregion

        #endregion

        #region Receiver

        #region RegisterResponse
        public void RegisterResponse(ushort responseOrderID, byte result, string authentication)
        {
            this.authenticationCode = authentication;
            this.isRegisted = (result == 0);

            //Auth 
            this.Authentication();
        }

        public void PlatCommonResponse(ushort responseOrderID, byte result)
        {

        }
        #endregion



        #endregion
    }
}
