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


        private double money = 0;
        private double oneDefaultMoney, oneCurrentPrice, twoDefaultMoney, twoCurrentPrice;

        public GamePage()
        {
            InitializeComponent();

            var one = _improvementService.GetImprovement("one");
            oneDefaultMoney = one.DefaultMoney;
            oneCurrentPrice = one.CurrentPrice;

            var two = _improvementService.GetImprovement("two");
            twoDefaultMoney = two.DefaultMoney;
            twoCurrentPrice = two.CurrentPrice;

            GetGameDataFromDb();
            RefreshOneProgress(_cancellationTokenSource.Token);
            RefreshTwoProgress(_cancellationTokenSource.Token);
            moneyTxt.Text = money.ToString();
        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show(Resources["back2HomePageMB"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);
            SetGameFromDb();
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomePage());
            }
        }

        ///<summary>
        ///Database içerisinde oyun için gerekli olan tüm bilgileri günceller. Oyunu kapatırken ya da önceki menüye dönmek istenildiğinde kullanılır.
        ///</summary>
        public void SetGameFromDb()
        {
            OneSetImprovement();
            TwoSetImprovement();
        }

        ///<summary>
        ///Database'den oyun için gerekli olan tüm bilgileri getirir. Bu bilgiler sayesinde oyunda kullanılacak olan ve en son kayıt edilmiş bilgiler getirilir. Oyun ekranının constructor'ında çağırılması yeterlidir.
        ///</summary>
        public void GetGameDataFromDb()
        {
            OneGetImprovement();
            TwoGetImprovement();
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
        }

        private void TwoGetImprovement()
        {
            var improvement = _improvementService.GetImprovement("two");
            twoUpgradeCountTxt.Text = improvement.UpgradeCount.ToString();
            twoCurrentPrice = improvement.CurrentPrice;
            twoProgBar.Maximum = improvement.TimeMs * 1000;
            twoDurationTxt.Text = $"00:00:0{improvement.TimeMs}";
            twoMoneyTxt.Text = (Convert.ToDouble(twoUpgradeCountTxt.Text) * twoDefaultMoney).ToString();
        }


        private void OneSetImprovement()
        {
            var one = _improvementService.GetImprovement("one");
            one.CurrentPrice = oneCurrentPrice;
            one.UpgradeCount = Convert.ToInt32(oneUpgradeCountTxt.Text);
            _improvementService.UpdateImprovement(one);
        }

        private void TwoSetImprovement()
        {
            var two = _improvementService.GetImprovement("two");
            two.CurrentPrice = twoCurrentPrice;
            two.UpgradeCount = Convert.ToInt32(twoUpgradeCountTxt.Text);
            _improvementService.UpdateImprovement(two);
        }

        public async void RefreshOneProgress(CancellationToken cancellationToken)
        {
            while (true)
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
