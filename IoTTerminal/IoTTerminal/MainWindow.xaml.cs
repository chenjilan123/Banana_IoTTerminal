using IoTTerminal.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace IoTTerminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DependencyInjection();
        }

        private void DependencyInjection()
        {
            IUnityContainer c = new UnityContainer();
            c.RegisterType<Terminal, JTB1076Terminal>();
            c.RegisterType<Terminal, JTB1076Terminal>("JTB1076");
            c.RegisterType<Terminal, JTB808Terminal>("JTB808");

            //var x= c.Resolve<Terminal>();
        }
    }
}
