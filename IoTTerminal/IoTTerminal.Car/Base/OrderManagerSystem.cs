using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Car.Base
{
    public class OrderManagerSystem
    {

        public void AddOrder(ushort messageID, ushort orderID)
        {

        }
        public bool IsResponse(ushort messageID, ushort responseOrderID)
        {
            return true;
        }
    }
}
