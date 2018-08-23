using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car.Base
{
    public class OrderManageSystem
    {
        //Concurrent Safety?
        /// <summary>
        /// OrderID - MessageID
        /// </summary>
        private Dictionary<ushort, ushort> dicWaitRespondOrder;
        public OrderManageSystem()
        {
            this.dicWaitRespondOrder = new Dictionary<ushort, ushort>();
        }
        public void AddOrder(ushort orderID, ushort messageID)
        {
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
