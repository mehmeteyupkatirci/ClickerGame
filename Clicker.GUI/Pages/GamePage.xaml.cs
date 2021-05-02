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

        private Improvement one, two, three, four, five, six, seven, eight, nine, ten;

        private double money = 0;

        public GamePage()
        {
            InitializeComponent();

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

        public async void RefreshOneProgress(CancellationToken cancellationToken)
        {

            while (true)
            {
                await Task.Delay(200);
                oneProgBar.Value += 200;
                oneMoneyTxt.Text = (Convert.ToDouble(one.UpgradeCount) * one.DefaultMoney).ToString();

                if (!(Convert.ToDouble(moneyTxt.Text) >= one.CurrentPrice))
                    oneBuyButton.IsEnabled = false;
                else
                    oneBuyButton.IsEnabled = true;

                if (oneProgBar.Value >= oneProgBar.Maximum)
                {
                    moneyTxt.Text = (Convert.ToDouble(oneMoneyTxt.Text) + Convert.ToDouble(moneyTxt.Text)).ToString();
                    if (one.Manager == true)
                    {
                        oneProgBar.Value = 0;
                    }
                }
            }
        }
        public async void RefreshTwoProgress(CancellationToken cancellationToken)
        {
            if (two.Manager == true)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(200);
                    twoProgBar.Value += 200;
                    twoMoneyTxt.Text = (Convert.ToDouble(twoUpgradeCountTxt.Text) * two.DefaultMoney).ToString();

                    if (!(Convert.ToDouble(moneyTxt.Text) >= two.CurrentPrice))
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
        }

        private void oneProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (oneProgBar.Value == (one.TimeMs * 1000))
            {
                money = (one.UpgradeCount * one.DefaultMoney) + money;
                moneyTxt.Text = money.ToString();
                oneProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Daha dolmadı!");
            }
        }

        private void oneBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= one.CurrentPrice)
            {
                one.UpgradeCount += 1;
                money = money - one.CurrentPrice;
                one.CurrentPrice *= 1.21;
                ChangeOneProperties();
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeOneProperties()
        {
            oneUpgradeCountTxt.Text = one.UpgradeCount.ToString();
            oneMoneyTxt.Text = (one.UpgradeCount * one.DefaultMoney).ToString();
            oneBuyButton.Content = $"${one.CurrentPrice} {Resources["buy"]}";
            oneProgBar.Maximum = one.TimeMs * 1000;
            oneDurationTxt.Text = $"00:00:0{one.TimeMs}";
            moneyTxt.Text = money.ToString();
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
            if (Convert.ToDouble(moneyTxt.Text) >= two.CurrentPrice)
            {
                twoUpgradeCountTxt.Text = (Convert.ToDouble(twoUpgradeCountTxt.Text) + 1).ToString();
                moneyTxt.Text = (Convert.ToDouble(moneyTxt.Text) - two.CurrentPrice).ToString();
                two.CurrentPrice = Math.Round(two.DefaultMoney * Math.Pow(1.15, Convert.ToDouble(twoUpgradeCountTxt.Text)), 1);
                twoBuyButton.Content = $"${two.CurrentPrice} {Resources["buy"]}";
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region DBOperations
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
    }
}
