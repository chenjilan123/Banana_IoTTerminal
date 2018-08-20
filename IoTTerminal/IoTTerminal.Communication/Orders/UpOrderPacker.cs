using IoTTerminal.Communication.Interface;
using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Orders
{
    public class UpOrderPacker : IUpOrderPacker
    {
        private const byte spliter = 0x7E;
        private readonly string simnum;
        private readonly DataEncoder encoder;
        private readonly DataDecoder decoder;
        public UpOrderPacker(string simnum)
        {
            this.simnum = simnum;
            this.encoder = new DataEncoder();
            this.decoder = new DataDecoder();
        }
        public byte[] Register(long provinceID, long cityID, string producerID, string terminalType, string platenum, byte platecolor)
        {
            List<byte> dataLst = new List<byte>();

            var provice = encoder.Encode(provinceID);
            var city = encoder.Encode(cityID);
            var producer = encoder.Encode(producerID);
            var terminal = encoder.Encode(terminalType);
            var plate = encoder.Encode(platenum);



            return new byte[] { 0x7e, 0x7e};
        }
        public byte[] Authentication(string authenticationNumber)
        {
            throw new NotImplementedException();
        }
        public byte[] Heartbeat()
        {
            throw new NotImplementedException();
        }

        public byte[] Position()
        {
            throw new NotImplementedException();
        }

    }
}
