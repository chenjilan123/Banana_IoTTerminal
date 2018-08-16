using IoTTerminal.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace IoTTerminal.DI
{
    public class IoTContainer
    {
        internal static void Register()
        {
            //如何添加参数
            //IUnityContainer c = new UnityContainer();
            //c.RegisterType<Vehicle, JTB1076Terminal>();
            //c.RegisterType<Vehicle, JTB1076Terminal>("JTB1076");
            //c.RegisterType<Vehicle, JTB808Terminal>("JTB808");

            //var x= c.Resolve<Terminal>();
        }
    }
}
