using IoTTerminal.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class Terminal
    {
        private JTB808Terminal terminal = new JTB808Terminal("218.5.10.82", 21005, "鄂A56789", 2, "13800000001", "A100001");

        [Fact]
        public void Register_TEST()
        {
            terminal.Register();
        }
    }
}
