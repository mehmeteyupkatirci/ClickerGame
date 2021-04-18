using Clicker.Business.Concrete;
using Clicker.Entities.Concrete;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Clicker.GUI.Pages
{
    public partial class GamePage : Page
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        ImprovementService _improvementService = new ImprovementService();

        private double money = 20;

        private double oneDefaultMoney = 5;
        private double oneCurrentPrice = 10;

        private double twoDefaultMoney = 50;
        private double twoCurrentPrice = 500;

        public GamePage()
        {
            InitializeComponent();
            
            SetGameFromDb();
            RefreshOneProgress(_cancellationTokenSource.Token);
            RefreshTwoProgress(_cancellationTokenSource.Token);
            moneyTxt.Text = money.ToString();
        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show(Resources["back2HomePageMB"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);
            SetGameFromDb(true);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomePage());
            }
        }

        ///<summary>
        ///Database'de bulunan tabloda(improvements) oyun için gerekli olan tüm bilgileri günceller. 
        ///</summary>
        public void SetGameFromDb(bool isUpdate)
        {
            OneSetImprovement();
        }

        ///<summary>
        ///Database'den oyun için gerekli olan tüm bilgileri getirir. Bu bilgiler sayesinde oyunda kullanılacak olan ve en son kayıt edilmiş bilgiler getirilir.
        ///</summary>
        public void SetGameFromDb()
        {
            OneGetImprovement();
        }

        private void OneGetImprovement()
        {
            //Improvement ımprovement = new Improvement() {Id = "test", StartPrice = 2, CurrentPrice = 1, Manager = true, TimeMs = 20, UpgradeCount = 23};
            //_improvementService.Add(ımprovement);
            var improvement = _improvementService.GetImprovement("one");
            oneUpgradeCountTxt.Text = improvement.UpgradeCount.ToString();
            oneCurrentPrice = improvement.CurrentPrice;
            oneProgBar.Maximum = improvement.TimeMs * 1000;
            oneDurationTxt.Text = $"00:00:0{improvement.TimeMs}";
            oneMoneyTxt.Text = (Convert.ToDouble(oneUpgradeCountTxt.Text) * oneDefaultMoney).ToString();

            twoProgBar.Maximum = 10000;
        }

        private void OneSetImprovement()
        {
            var improvement = _improvementService.GetImprovement("one");
            improvement.CurrentPrice = oneCurrentPrice;
            improvement.UpgradeCount = Convert.ToInt32(oneUpgradeCountTxt.Text);
            _improvementService.UpdateImprovement(improvement);
        }

        public async void RefreshOneProgress(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(200);
                oneProgBar.Value += 200;
                oneMoneyTxt.Text = (Convert.ToDouble(oneUpgradeCountTxt.Text) * oneDefaultMoney).ToString();
                
                if (!(Convert.ToDouble(moneyTxt.Text) >= oneCurrentPrice))
                    oneBuyButton.IsEnabled = false;
                else
                    oneBuyButton.IsEnabled = true;

                if (oneProgBar.Value >= oneProgBar.Maximum)
                {
                    moneyTxt.Text = (Convert.ToDouble(oneMoneyTxt.Text) + Convert.ToDouble(moneyTxt.Text)).ToString();
                    oneProgBar.Value = 0;
                }
            }
        }
        public async void RefreshTwoProgress(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(200);
                twoProgBar.Value += 200;
                twoMoneyTxt.Text = (Convert.ToDouble(twoUpgradeCountTxt.Text) * twoDefaultMoney).ToString();

                if (!(Convert.ToDouble(moneyTxt.Text) >= twoCurrentPrice))
                    twoBuyButton.IsEnabled = false;
                else
                    twoBuyButton.IsEnabled = true;

                if (twoProgBar.Value >= twoProgBar.Maximum)
                {
                    moneyTxt.Text = (Convert.ToDouble(twoMoneyTxt.Text) + Convert.ToDouble(moneyTxt.Text)).ToString();
                    twoProgBar.Value = 0;
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

        private void twoProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (twoProgBar.Value == twoProgBar.Maximum)
            {
                moneyTxt.Text = (Convert.ToDouble(oneMoneyTxt.Text) + Convert.ToDouble(moneyTxt.Text)).ToString();
                oneProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("!");
            }
        }

        private void twoBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(moneyTxt.Text) >= twoCurrentPrice)
            {
                twoUpgradeCountTxt.Text = (Convert.ToDouble(twoUpgradeCountTxt.Text) + 1).ToString();
                moneyTxt.Text = (Convert.ToDouble(moneyTxt.Text) - twoCurrentPrice).ToString();
                twoCurrentPrice = Math.Round(twoDefaultMoney * Math.Pow(1.15, Convert.ToDouble(twoUpgradeCountTxt.Text)), 1);
                twoBuyButton.Content = $"${twoCurrentPrice} {Resources["buy"]}";
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
