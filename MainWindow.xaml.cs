using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Clicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double money;
        public double mps;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            MPSTextUpdate(_cancellationTokenSource.Token);
            this.Closing += (sender, e) => _cancellationTokenSource.Cancel();
            InitializeComponent();
        }

        #region Title Bar

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MyTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;
                else
                    WindowState = WindowState.Maximized;
            }

            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnNormal_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        #endregion

        public String ShortNumbersMaker(double number)
        {
            const int Digits = 1;
            if (number < 1000d)
            {
                return number.ToString();
            }
            else if (number < 1000000d)
            {
                number /= 1000d;
                number = Math.Round(number, Digits);
                return number.ToString() + "k";
            }
            else if (number < 1000000000d)
            {

                number /= 1000000d;
                number = Math.Round(number, Digits);
                return number.ToString() + "M";
            }
            else if (number < 1000000000000d)
            {
                number /= 1000000000d;
                number = Math.Round(number, Digits);
                return number.ToString() + "G";
            }
            else if (number < 1000000000000000d)
            {
                number /= 1000000000000d;
                number = Math.Round(number, Digits);
                return number.ToString() + "T";
            }
            else if (number < 1000000000000000000d)
            {
                number /= 1000000000000000d;
                number = Math.Round(number, Digits);
                return number.ToString() + "P";
            }
            else if (number < 1000000000000000000000d)
            {
                number /= 1000000000000000000d;
                number = Math.Round(number, Digits);
                return number.ToString() + "E";
            }
            else if (number < 1000000000000000000000000d)
            {
                number /= 1000000000000000000000d;
                number = Math.Round(number, Digits);
                return number.ToString() + "Z";
            }
            else
            {
                number /= 1000000000000000000000000d;
                number = Math.Round(number, Digits);
                return number.ToString() + "Y";
            }
        }

        public async void MPSTextUpdate(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(1000, cancellationToken);
                    money += mps;
                    moneyLabel.Content = ShortNumbersMaker(money);
                }
                catch (Exception e)
                {
                    if (!cancellationToken.IsCancellationRequested) 
                    {
                        Close();
                        return;
                    }
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            money += 1;
            moneyLabel.Content = money;
            //Random rnd = new Random();
            //controller.ClickButton();
            //ClickPointAddLabel.Margin = new Thickness(rnd.Next(0, 150), rnd.Next(0, 150), rnd.Next(0, 150), rnd.Next(0, 150));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (money >= 5)
            {
                money -= 5;
                mps += 1;
            }
            moneyPSLabel.Content = mps;
        }
    }
}
