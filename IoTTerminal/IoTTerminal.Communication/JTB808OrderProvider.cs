using IoTTerminal.Communication.Interface;
using IoTTerminal.Communication.Orders;
using IoTTerminal.Communication.SocketPool;
using IoTTerminal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication
{
    public class JTB808OrderProvider : IUpOrderProvider
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
        private Client client;
        #endregion

        #region Property
        public string SimNum => simnum;
        public string Ip => ip;
        public int Port => port;
        #endregion

        #region Constructor
        public JTB808OrderProvider(string simnum, string ip, int port, IDownOrderParser parser, IUpOrderPacker packer, Client client)
        {
            this.simnum = simnum;
            this.ip = ip;
            this.port = port;
            this.parser = parser;
            this.packer = packer;
            this.client = client;
        }
        #endregion

        #region Up Command to Platform
        private void SendAsync(byte[] data)
        {
            client.SendAsync(data);
        }
        public ushort Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor)
        {
            client.Connect();
            var data = packer.Register(provinceID, cityID, producerID, terminalType, terminalID, platenum, platecolor, out ushort headerOrderID);
            SendAsync(data);
            return headerOrderID;
        }


        public ushort Authentication(string authenticationNumber)
        {
            var data = packer.Authentication(authenticationNumber, out ushort headerOrderID);
            SendAsync(data);
            return headerOrderID;
        }

        public ushort Logout()
        {
            var data = packer.Logout(out ushort headerOrderID);
            SendAsync(data);
            return headerOrderID;
        }
        public ushort Heartbeat()
        {
            var data = packer.Heartbeat(out ushort headerOrderID);
            SendAsync(data);
            return headerOrderID;
        }

        public ushort Position(uint alarmFlag, uint status, uint lontitude, uint latitude, ushort height, ushort speed, ushort direction, string time)
        {
            var data = packer.Position(alarmFlag, status, lontitude, latitude, height, speed, direction, time, out ushort headerOrderID);
            SendAsync(data);
            return headerOrderID;
        }

        public ushort UpCommand(Command command)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
