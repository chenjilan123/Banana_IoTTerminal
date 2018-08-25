using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car.Base
{
    public class OrderManageSystem
    {
        /// <summary>
        /// Resend orders when overtime
        /// </summary>
        private readonly JTB808Terminal jtb808Terminal;
        //Concurrent Safety?
        /// <summary>
        /// OrderID - MessageID
        /// </summary>
        private Dictionary<ushort, ushort> dicWaitRespondOrder;
        public OrderManageSystem(JTB808Terminal jtb808Terminal)
        {
            this.dicWaitRespondOrder = new Dictionary<ushort, ushort>();
            this.jtb808Terminal = jtb808Terminal;
        }
        public void AddOrder(ushort orderID, ushort messageID)
        {
            if (dicWaitRespondOrder.ContainsKey(orderID))
            {
                //直接覆盖原指令。
                dicWaitRespondOrder[orderID] = messageID;
            }
            else
                dicWaitRespondOrder.Add(orderID, messageID);
        }

        public bool IsResponse(ushort responseOrderID, ushort messageID)
        {
            if (!dicWaitRespondOrder.ContainsKey(responseOrderID) || dicWaitRespondOrder[responseOrderID] != messageID)
                return false;
            dicWaitRespondOrder.Remove(responseOrderID);
            return true;
        }
    }
}
