using IoTTerminal.Communication.Interface;
using IoTTerminal.Communication.Orders;
using IoTTerminal.Communication.SocketPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication
{
    public class JTB808OrderProvider : IOrderProvider
    {
        #region Enumerable
        //Open to configuration file
        private static Dictionary<string, uint> orderMapping;
        public static Dictionary<string, uint> OrderMapping
        {
            get
            {
                if (orderMapping == null)
                {
                    orderMapping = new Dictionary<string, uint>();
                    orderMapping.Add(nameof(Position), 0x0200);
                    orderMapping.Add(nameof(Register), 0x8000);
                }
                return orderMapping;
            }
        }
        #endregion

        #region Field
        private readonly string simnum;
        private readonly string ip;
        private readonly int port;
        private readonly IDownOrderParser parser;
        private readonly IUpOrderPacker packer;
        private string authenticationCode;
        private bool IsRegisted = false;
        private bool IsAuthenticated = false;
        private Client client;
        #endregion

        #region Property
        public string SimNum => simnum;
        public string Ip => ip;
        public int Port => port;
        #endregion

        #region Constructor
        public JTB808OrderProvider(string simnum, string ip, int port)
        {
            this.simnum = simnum;
            this.ip = ip;
            this.port = port;
            this.client = new Client(ip, port);
            this.parser = new DownOrderParser();
            this.packer = new UpOrderPacker(simnum);
        }
        #endregion

        #region Up Command to Platform
        private void SendAsync(byte[] data)
        {
            client.SendAsync(data);
        }
        public void Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor)
        {
            client.Connect();
            var data = packer.Register(provinceID, cityID, producerID, terminalType, terminalID, platenum, platecolor);
            SendAsync(data);
        }


        public void Authentication(string authenticationNumber)
        {
            var data = packer.Authentication(authenticationNumber);
            SendAsync(data);
        }

        public void Heartbeat()
        {
            var data = packer.Heartbeat();
            SendAsync(data);
        }

        public void Position()
        {
            var data = packer.Position();
            SendAsync(data);
        }
        
        #endregion

        #region Plateform Down Command

        #endregion
    }
}
