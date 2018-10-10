using IoTTerminal.Communication.Interface;
using IoTTerminal.Communication.Utinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication.Orders
{
    public class DownOrderParser : IDownOrderParser
    {
        #region Field
        private const byte propertyLengthMask = 0x3F;
        private readonly IDownOrderReceiver receiver;
        private readonly DataDecoder decoder;
        #endregion

        #region Map
        //Concurrently Safe?
        private static Dictionary<ushort, string> messageHandlerMap;

        public static void InitMessageHandlerMap()
        {
            if (messageHandlerMap == null)
            {
                messageHandlerMap = new Dictionary<ushort, string>();
                messageHandlerMap.Add(0x8001, nameof(PlatCommonResponse));
                messageHandlerMap.Add(0x8100, nameof(RegisterResponse));
            }
        }

        #endregion

        #region Constructor
        static DownOrderParser()
        {
            InitMessageHandlerMap();
        }

        public DownOrderParser(IDownOrderReceiver receiver)
        {
            this.receiver = receiver;
            this.decoder = new DataDecoder();
        }
        #endregion

        #region ReceiveMessage
        /// <summary>
        /// ReceiveMessage
        /// -- -----------------------------------------------------------------------------------------------------------------------------
        /// -- Identifier   Message ID    Property   Sim Number       Order ID     Body                        Check Code  Idenfifier     --
        /// -- 7E           8100          000D       013100000000     F1D8         02810030383233313333383438  1A          7E             --
        /// --------------------------------------------------------------------------------------------------------------------------------
        /// </summary>
        /// <param name="data">"7Exxxxxxxx7E"  Representate a complete message</param>
        public void ReceiveMessage(byte[] data)
        {
            var messageID = decoder.DecodeToUshort(data, 1);
            if (!messageHandlerMap.ContainsKey(messageID))
            {
                //Error log for not implement message
                //Logger.Error($"{messageID} message not implement yet.");
                return;
            }

            //var simnum = GetSimNumber(data); //Useful?
            //check code?

            //Reflection to message handler
            var bodyLength = GetBodyLength(data);
            var body = new byte[bodyLength];
            var orderID = decoder.DecodeToUshort(data, 11);
            Array.Copy(data, 13, body, 0, body.Length);
            var handlerMethodName = messageHandlerMap[messageID];
            var classInfo = typeof(DownOrderParser);
            var methodInfo = classInfo.GetMethod(handlerMethodName);
            var parameters = new object[] { orderID, body };
            methodInfo.Invoke(this, parameters);
        }

        private string GetSimNumber(byte[] data)
        {
            var simnumData = new byte[6];
            Array.Copy(data, 5, simnumData, 0, simnumData.Length);
            return decoder.DecodeBCD(simnumData);
        }

        private ushort GetBodyLength(byte[] data)
        {
            var propertyData = new byte[2];
            Array.Copy(data, 3, propertyData, 0, propertyData.Length);
            propertyData[1] = (byte)(propertyData[1] & propertyLengthMask);

            return decoder.DecodeToUshort(propertyData);
        }
        #endregion

        #region Interface
        public void PlatCommonResponse(ushort orderID, byte[] body)
        {
            var responseOrderID = decoder.DecodeToUshort(body);
            var result = body[4];
            receiver.PlatCommonResponse(responseOrderID, result);
        }

        public void RegisterResponse(ushort orderID, byte[] body)
        {
            var responseOrderID = decoder.DecodeToUshort(body);
            var result = body[2];
            var authData = new byte[body.Length - 3];
            Array.Copy(body, 3, authData, 0, authData.Length);
            var authentication = decoder.DecodeToString(authData);
            receiver.RegisterResponse(responseOrderID, result, authentication);
        }

        public void DownCommand(ushort orderID, byte[] body)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
