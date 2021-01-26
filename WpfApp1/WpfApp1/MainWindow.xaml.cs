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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] mass1 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        string[] mass2 = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p"};
        string log = "P";
        string pass = "ppp";
        int a = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 90);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ulog.ToString() != log || upass.ToString() != pass)
            {
                a += 1;
                if (a == 3)
                {
                    cap.Visibility = Visibility.Visible;
                    ucap.Visibility = Visibility.Visible;
                    bt.Click += bt_Click;
                    capp();
                }
            }
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            if(ulog.ToString() != log || upass.ToString() != pass || ucap.ToString() != cap.ToString())
            {
                cap.Text = "";
                ucap.Text = "";
                capp();
            }
        }

        private void capp()
        {
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                int b = rnd.Next(0, 2);
                if (b == 0)
                {
                    b = rnd.Next(0, 10);
                    cap.Text += mass1[b].ToString();
                }
                else if (b == 1)
                {
                    b = rnd.Next(0, 10);
                    cap.Text += mass2[b].ToString();
                }
            }
        }
    }


}
