using IoTTerminal.Car.Base;
using IoTTerminal.Car.TerminalSystem;
using IoTTerminal.Communication;
using IoTTerminal.Communication.Interface;
using IoTTerminal.Communication.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace IoTTerminal.Car
{
    public class JTB808Terminal : Vehicle, IDownOrderReceiver
    {
        #region Static
        private static Dictionary<string, ushort> orderMap;

        private static Dictionary<string, ushort> OrderMap
        {
            get
            {
                if (orderMap == null)
                {
                    orderMap = new Dictionary<string, ushort>();
                    orderMap.Add(nameof(RegisterResponse), (ushort)DownMessageID.RegisterResponse);
                    orderMap.Add(nameof(PlatCommonResponse), (ushort)DownMessageID.PlatCommonResponse);
                }
                return orderMap;
            }
        }
        #endregion

        #region Field
        private readonly IUpOrderSender iOrderProvider;
        private readonly OrderManageSystem orderManageSystem;
        private readonly GpsSystem gpsSystem;
        private readonly Timer heartTimer;
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
            orderManageSystem = new OrderManageSystem(this);
            gpsSystem = new GpsSystem();
            heartTimer = new Timer(3000);
            heartTimer.Elapsed += HeartTimer_Elapsed; ;
        }

        private void HeartTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            heartTimer.Enabled = false;
            Heartbeat();
            heartTimer.Enabled = true;
        }
        #endregion

        #region Sender

        #region Register
        public void Register()
        {
            var orderID = iOrderProvider.Register(0, 0, "12321", "132", this.terminalID, this.platenum, this.platecolor);
            //异步可能导致应答收到了，指令还未添加。
            orderManageSystem.AddOrder(orderID, OrderMap[nameof(RegisterResponse)]);
        }
        #endregion

        #region Authentication
        public void Authentication()
        {
            var orderID = iOrderProvider.Authentication(authenticationCode);
            orderManageSystem.AddOrder(orderID, OrderMap[nameof(PlatCommonResponse)]);

        }
        #endregion

        #region Heartbeat
        public void Heartbeat()
        {
            var orderID = iOrderProvider.Heartbeat();
            orderManageSystem.AddOrder(orderID, OrderMap[nameof(PlatCommonResponse)]);
        }
        #endregion

        #region Position
        public void Position()
        {
            (double lon, double lat) = gpsSystem.NextPosition();
            var orderID = iOrderProvider.Position(0, 0, (uint)(lon * 1000000), (uint)(lat * 1000000), 0, 70, 0, DateTime.Now.ToString("yyMMddHHmmss"));
        }
        #endregion

        #endregion

        #region Receiver

        #region RegisterResponse
        public void RegisterResponse(ushort responseOrderID, byte result, string authentication)
        {
            if (!IsResponse(responseOrderID, nameof(RegisterResponse)))
                return;
            this.authenticationCode = authentication;
            this.isRegisted = (result == 0);
            //Auth 
            this.Authentication();
            this.heartTimer.Enabled = true;
        }
        #endregion

        #region PlatCommonResponse
        public void PlatCommonResponse(ushort responseOrderID, byte result)
        {
            if (!IsResponse(responseOrderID, nameof(PlatCommonResponse)))
                return;

        }
        #endregion

        #endregion

        #region IsResponse
        private bool IsResponse(ushort responseOrderID, string methodName)
        {
            if (!OrderMap.ContainsKey(methodName))
            {
                //throw new Exception($"{methodName} do not map to a message id");
            }
            return orderManageSystem.IsResponse(responseOrderID, OrderMap[methodName]);
        }
        #endregion
    }
}
