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
        ImprovementService _improvementService = new ImprovementService();
        ConfigurationDataService _configurationDataService = new ConfigurationDataService();

        private Improvement one, two, three, four, five, six, seven, eight, nine, ten;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private double money = 0;

        public GamePage()
        {
            InitializeComponent();

            GetGameDataFromDb();
            Refresh(_cancellationTokenSource.Token);
            MoneyWriter();
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

        public async void Refresh(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(200);
                OneRefresh();
                TwoRefresh();
            }
        }

        #region Refresh Operations

        private void OneRefresh()
        {
            oneProgBar.Value += 200;
            oneMoneyTxt.Text = (one.UpgradeCount * one.DefaultMoney).ToString();

            if (!(money >= one.CurrentPrice))
                oneBuyButton.IsEnabled = false;
            else
                oneBuyButton.IsEnabled = true;

            if (oneProgBar.Value >= (one.TimeMs * 1000) && one.Manager)
            {
                money = (one.UpgradeCount * one.DefaultMoney) + money;
                MoneyWriter();
                oneProgBar.Value = 0;
            }
        }

        private void TwoRefresh()
        {
            twoProgBar.Value += 200;
            twoMoneyTxt.Text = (two.UpgradeCount * two.DefaultMoney).ToString();

            if (!(money >= two.CurrentPrice))
                twoBuyButton.IsEnabled = false;
            else
                twoBuyButton.IsEnabled = true;

            if (twoProgBar.Value >= (two.TimeMs * 1000) && two.Manager)
            {
                money = (two.UpgradeCount * two.DefaultMoney) + money;
                MoneyWriter();
                oneProgBar.Value = 0;
            }
        }

        #endregion

        #region ProgressBar DoubleClicks
       
        private void oneProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (oneProgBar.Value == (one.TimeMs * 1000))
            {
                money = (one.UpgradeCount * one.DefaultMoney) + money;
                MoneyWriter();
                oneProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Daha dolmadı!");
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

        #endregion

        #region Buy Buttons

        private void oneBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= one.CurrentPrice)
            {
                one.UpgradeCount += 1;
                money = money - one.CurrentPrice;
                one.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeOneProperties();
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void twoBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(moneyTxt.Text) >= two.CurrentPrice)
            {
                twoUpgradeCountTxt.Text = (two.UpgradeCount + 1).ToString();
                moneyTxt.Text = (Convert.ToDouble(moneyTxt.Text) - two.CurrentPrice).ToString();
                two.CurrentPrice = Math.Round(two.DefaultMoney * Math.Pow(1.15, Convert.ToDouble(twoUpgradeCountTxt.Text)), 1);
                twoBuyButton.Content = $"${two.CurrentPrice} {Resources["buy"]}";
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region DBOperations

        ///<summary>
        ///Database içerisinde oyun için gerekli olan tüm bilgileri günceller. Oyunu kapatırken ya da önceki menüye dönmek istenildiğinde kullanılır.
        ///</summary>
        public void SetGameFromDb()
        {
            Convert.ToDouble(_configurationDataService.UpdateConfigurationData("money", money.ToString()));
            OneSetImprovement();
            TwoSetImprovement();
        }

        ///<summary>
        ///Database'den oyun için gerekli olan tüm bilgileri getirir. Bu bilgiler sayesinde oyunda kullanılacak olan ve en son kayıt edilmiş bilgiler getirilir. Oyun ekranının constructor'ında çağırılması yeterlidir.
        ///</summary>
        public void GetGameDataFromDb()
        {
            money = Convert.ToDouble(_configurationDataService.GetConfigurationData("money").Value);
            OneGetImprovement();
            TwoGetImprovement();
        }

        private void OneGetImprovement()
        {
            one = _improvementService.GetImprovement("one");
            ChangeOneProperties();
        }

        private void TwoGetImprovement()
        {
            two = _improvementService.GetImprovement("two");
            twoUpgradeCountTxt.Text = two.UpgradeCount.ToString();
            twoProgBar.Maximum = two.TimeMs * 1000;
            twoDurationTxt.Text = $"00:00:0{two.TimeMs}";
            twoMoneyTxt.Text = (Convert.ToDouble(two.UpgradeCount) * two.DefaultMoney).ToString();
        }

        private void OneSetImprovement()
        {
            _improvementService.UpdateImprovement(one);
        }

        private void TwoSetImprovement()
        {
            _improvementService.UpdateImprovement(two);
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Sadece GUI'de bulunan MoneyText kısmını değiştirir. Çok fazla yerde kullanıldığı için extra method yapma ihtiyacı duydum. Ayrıca milyondan sonra gösterim kısmında harf eklemek için lazım!
        /// </summary>
        private void MoneyWriter()
        {
            moneyTxt.Text = Math.Round(money, 1).ToString();
        }

        private void ChangeOneProperties()
        {
            oneUpgradeCountTxt.Text = one.UpgradeCount.ToString();
            oneMoneyTxt.Text = Math.Round((one.UpgradeCount * one.DefaultMoney), 1).ToString();
            oneBuyButton.Content = $"${Math.Round(one.CurrentPrice, 1)} {Resources["buy"]}";
            oneProgBar.Maximum = one.TimeMs * 1000;
            oneDurationTxt.Text = $"00:00:0{one.TimeMs}";
        }
        #endregion
    }
}
