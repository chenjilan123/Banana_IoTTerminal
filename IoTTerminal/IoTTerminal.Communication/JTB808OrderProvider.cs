using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication
{
    public class JTB808OrderProvider : IOrderProvider
    {
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
        private readonly string simnum;
        public string SimNum => simnum;

        #region Constructor
        public JTB808OrderProvider(string simnum)
        {
            this.simnum = simnum;
        }
        #endregion

        #region Up Command to Platform
        public void Register(string platenum, string platecolor, string ip, int port)
        {

        }
        public void Authentication(string authenticationNumber)
        {
            throw new NotImplementedException();
        }

        public void Heartbeat()
        {
            throw new NotImplementedException();
        }

        public void Position()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Plateform Down Command

        #endregion
    }
}
