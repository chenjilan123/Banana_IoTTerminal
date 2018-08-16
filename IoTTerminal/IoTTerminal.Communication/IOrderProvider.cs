using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Communication
{
    public interface IOrderProvider
    {
        string SimNum { get; }
        void Register(string platenum, string platecolor, string ip, int port);
        void Authentication(string authenticationNumber);
        void Heartbeat();
        void Position();

    }
}
