using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTTerminal.Model
{
    public abstract class Command
    {
        public ushort OrderId { get; set; }
        public string SimNum { get; set; }
        public string PlateNum { get; set; }
        public uint MessageId { get; set; }
    }
}
