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

namespace Clicker.GUI.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private double money = 0;
        private double oneDefaultMoney = 5;
        private double oneCurrentPrice = 10;

        public GamePage()
        {
            InitializeComponent();
            oneUpgradeCountTxt.Text = 1.ToString();
            RefreshFirstProgress(_cancellationTokenSource.Token);
            moneyTxt.Text = money.ToString();
            oneMoneyTxt.Text = (Convert.ToDouble(oneUpgradeCountTxt.Text) * oneDefaultMoney).ToString();
        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show(Resources["back2HomePageMB"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomePage());
            }
        }

        public async void RefreshFirstProgress(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(200);
                oneProgBar.Value += 200;
                oneMoneyTxt.Text = (Convert.ToDouble(oneUpgradeCountTxt.Text) * oneDefaultMoney).ToString();
                if (oneProgBar.Value >= oneProgBar.Maximum)
                {
                    moneyTxt.Text = (Convert.ToDouble(oneMoneyTxt.Text) + Convert.ToDouble(moneyTxt.Text)).ToString();
                    oneProgBar.Value = 0;
                }
            }
        }

        private void oneProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (oneProgBar.Value == oneProgBar.Maximum)
            {
                moneyTxt.Text = (Convert.ToDouble(oneMoneyTxt.Text) + Convert.ToDouble(moneyTxt.Text)).ToString();
                oneProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("!");
            }
        }

        private void oneBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(moneyTxt.Text) >= oneCurrentPrice)
            {
                oneUpgradeCountTxt.Text = (Convert.ToDouble(oneUpgradeCountTxt.Text) + 1).ToString();
                moneyTxt.Text = (Convert.ToDouble(moneyTxt.Text) - oneCurrentPrice).ToString();
                oneCurrentPrice = Math.Round(oneDefaultMoney * Math.Pow(1.15, Convert.ToDouble(oneUpgradeCountTxt.Text)), 1);
                oneBuyButton.Content = $"${oneCurrentPrice} {Resources["buy"]}";
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK , MessageBoxImage.Error);
            }
        }
    }
}
