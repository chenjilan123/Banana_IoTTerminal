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
        private const byte identifierBit = 0x7E;
        private const byte transferBit = 0x7D;
        private readonly string simnum;
        private readonly DataEncoder encoder;
        private readonly DataDecoder decoder;
        private ushort orderID;
        public UpOrderPacker(string simnum)
        {
            this.simnum = simnum;
            this.encoder = new DataEncoder();
            this.decoder = new DataDecoder();
            this.orderID = (ushort)DateTime.Now.Millisecond;
        }
        /// <summary>
        /// ---------------------------------------------------------------------------------
        /// --                             Message Header                                  --
        /// ---------------------------------------------------------------------------------
        /// --  MessageID | Message Property |      SimNum     |  Order ID |  Package Top  --
        /// --       0000 |       0000       |  0000 0000 0000 |    0000   |               --
        /// ---------------------------------------------------------------------------------
        /// ---------------------------------------------------------------------------------
        /// </summary>
        /// <param name="messageName"></param>
        /// <param name="realBody">assume no subpackage</param>
        /// <returns></returns>
        private byte[] GetHeader(MessageID messageName, byte[] realBody)
        {
            var messageId = encoder.Encode((ushort)messageName);
            var messageProperty = encoder.Encode((ushort)realBody.Length);
            var simnumData = encoder.EncodeBCD(simnum, 12);
            var orderIDData = encoder.Encode(orderID++);
            IList<byte[]> lst = new List<byte[]>();
            lst.Add(messageId);
            lst.Add(messageProperty);
            lst.Add(simnumData);
            lst.Add(orderIDData);
            return GetFullData(lst);
        }
        private byte[] GetFullData(IList<byte[]> datas)
        {
            var dataLength = 0;
            foreach (var dataItem in datas)
                dataLength += dataItem.Length;
            var data = new byte[dataLength];
            var index = 0;
            for (int i = 0; i < datas.Count; i++)
            {
                Array.Copy(datas[i], 0, data, index, datas[i].Length);
                index += datas[i].Length;
            }
            return data;
        }
        private void TransferMeanning(ref byte[] data)
        {
            if (!data.Contains(identifierBit) && !data.Contains(identifierBit))
                return;
            var bufferLst = new List<byte>(data);

            var identifierIndex = bufferLst.IndexOf(identifierBit);
            while (identifierIndex > 0)
            {
                bufferLst[identifierIndex] = transferBit;
                bufferLst.Insert(identifierIndex + 1, 0x02);
                identifierIndex = bufferLst.IndexOf(identifierBit);
            }

            var transferIndex = bufferLst.IndexOf(transferBit);
            while (transferIndex > 0)
            {
                bufferLst.Insert(transferBit + 1, 0x01);
                transferIndex = bufferLst.IndexOf(transferBit);
            }
            data = bufferLst.ToArray();
        }
        private byte[] GetFullPackage(byte[] body, MessageID messageName)
        {
            TransferMeanning(ref body);
            var header = GetHeader(messageName, body);
            TransferMeanning(ref header);

            byte[] package = new byte[3 + body.Length + header.Length];
            byte checkCode = 0x00;
            foreach (var dataItem in header)
            {
                checkCode ^= dataItem;
            }
            foreach (var dataItem in body)
            {
                checkCode ^= dataItem;
            }
            package[0] = identifierBit;
            package[package.Length - 1] = identifierBit;
            package[package.Length - 2] = checkCode;

            Array.Copy(header, 0, package, 1, header.Length);
            Array.Copy(body, 0, package, 1 + header.Length, body.Length);
            return package;
        }
        public byte[] Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor)
        {
            List<byte> dataLst = new List<byte>();

            var provice = encoder.Encode(provinceID);
            var city = encoder.Encode(cityID);
            var producer = encoder.Encode(producerID, 5);
            var terminal = encoder.Encode(terminalType, 20);
            var terminalIDData = encoder.Encode(terminalID, 7);
            var plate = encoder.EncodeString(platenum);

            var body = new byte[provice.Length + city.Length + producer.Length + terminal.Length + terminalIDData.Length + plate.Length + 1];
            var index = 0;
            Array.Copy(provice, 0, body, index, provice.Length);
            index += provice.Length;
            Array.Copy(city, 0, body, index, city.Length);
            index += city.Length;
            Array.Copy(producer, 0, body, index, producer.Length);
            index += producer.Length;
            Array.Copy(terminal, 0, body, index, terminal.Length);
            index += terminal.Length;
            Array.Copy(terminalIDData, 0, body, index, terminalIDData.Length);
            index += terminalIDData.Length;
            body[index] = platecolor;
            index++;
            Array.Copy(plate, 0, body, index, plate.Length);

            return GetFullPackage(body, MessageID.Register);
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
