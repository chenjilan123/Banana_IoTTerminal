﻿using IoTTerminal.Car;
using IoTTerminal.DI;
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
        private const string defaultPlateNumber = "鄂A56789";
        private const byte defaultPlateColor = 2;
        private const string defaultSimNumber = "13800000001";
        private const string defaultTerminalID = "AB10101";
        private string ip = "120.40.188.122";
        private int port = 8085;
        private JTB1076Terminal jtb1076 = null;

        public MainWindow()
        {
            InitializeComponent();

            //如果是长时间操作，别放这里，应放加载事件。
            IoTContainer.Register();
            jtb1076 = new JTB1076Terminal(ip, port, defaultPlateNumber, defaultPlateColor, defaultSimNumber, defaultTerminalID);
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            jtb1076?.Register();
        }
    }
}
