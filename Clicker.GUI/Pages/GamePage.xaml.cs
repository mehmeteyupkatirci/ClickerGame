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
                ThreeRefresh();
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

        private void ThreeRefresh()
        {
            threeProgBar.Value += 200;
            threeMoneyTxt.Text = (three.UpgradeCount * three.DefaultMoney).ToString();

            if (!(money >= three.CurrentPrice))
                threeBuyButton.IsEnabled = false;
            else
                threeBuyButton.IsEnabled = true;

            if (threeProgBar.Value >= (three.TimeMs * 1000) && three.Manager)
            {
                money = (three.UpgradeCount * three.DefaultMoney) + money;
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
            if (twoProgBar.Value == (two.TimeMs * 1000))
            {
                money = (two.UpgradeCount * two.DefaultMoney) + money;
                MoneyWriter();
                twoProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Hazır değil");
            }
        }
        private void threeProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (threeProgBar.Value == (three.TimeMs * 1000))
            {
                money = (three.UpgradeCount * three.DefaultMoney) + money;
                MoneyWriter();
                threeProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Hazır değil");
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
                ChangeProperties("one");
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void twoBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= two.CurrentPrice)
            {
                two.UpgradeCount += 1;
                money = money - two.CurrentPrice;
                two.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("two");
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void threeBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= three.CurrentPrice)
            {
                three.UpgradeCount += 1;
                money = money - three.CurrentPrice;
                three.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("three");
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
            SetAllImrpovement();
        }

        ///<summary>
        ///Database'den oyun için gerekli olan tüm bilgileri getirir. Bu bilgiler sayesinde oyunda kullanılacak olan ve en son kayıt edilmiş bilgiler getirilir. Oyun ekranının constructor'ında çağırılması yeterlidir.
        ///</summary>
        public void GetGameDataFromDb()
        {
            money = Convert.ToDouble(_configurationDataService.GetConfigurationData("money").Value);
            GetAllImprovement();
            ChangeProperties("all");
        }

        private void GetAllImprovement()
        {
            one = _improvementService.GetImprovement("one");
            two = _improvementService.GetImprovement("two");
            three = _improvementService.GetImprovement("three");
            four = _improvementService.GetImprovement("four");
            five = _improvementService.GetImprovement("five");
            six = _improvementService.GetImprovement("six");
            seven = _improvementService.GetImprovement("seven");
            eight = _improvementService.GetImprovement("eight");
            nine = _improvementService.GetImprovement("nine");
            ten = _improvementService.GetImprovement("ten");
        }

        private void SetAllImrpovement()
        {
            _improvementService.UpdateImprovement(one);
            _improvementService.UpdateImprovement(two);
            _improvementService.UpdateImprovement(three);
            _improvementService.UpdateImprovement(four);
            _improvementService.UpdateImprovement(five);
            _improvementService.UpdateImprovement(six);
            _improvementService.UpdateImprovement(seven);
            _improvementService.UpdateImprovement(eight);
            _improvementService.UpdateImprovement(nine);
            _improvementService.UpdateImprovement(ten);
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


        /// <summary>
        /// Bu fonksiyon içerisine aldığı sayının GUI'de bulunan ilgili yerlerini değiştirir. Mesela : three aldıysa 3. ye ait bütün görsel (textBox, progressBar vs.) yenilenmiş olur.
        /// </summary>
        /// <param name="number"></param>
        private void ChangeProperties(string number)
        {
            if (number == "all")
            {   //1
                oneUpgradeCountTxt.Text = one.UpgradeCount.ToString();
                oneMoneyTxt.Text = Math.Round((one.UpgradeCount * one.DefaultMoney), 1).ToString();
                oneBuyButton.Content = $"${Math.Round(one.CurrentPrice, 1)} {Resources["buy"]}";
                oneProgBar.Maximum = one.TimeMs * 1000;
                oneDurationTxt.Text = $"00:00:0{one.TimeMs}";
                //2
                twoUpgradeCountTxt.Text = two.UpgradeCount.ToString();
                twoMoneyTxt.Text = Math.Round((two.UpgradeCount * two.DefaultMoney), 1).ToString();
                twoBuyButton.Content = $"${Math.Round(two.CurrentPrice, 1)} {Resources["buy"]}";
                twoProgBar.Maximum = two.TimeMs * 1000;
                twoDurationTxt.Text = $"00:00:0{two.TimeMs}";
                //3
                threeUpgradeCountTxt.Text = three.UpgradeCount.ToString();
                threeMoneyTxt.Text = Math.Round((three.UpgradeCount * three.DefaultMoney), 1).ToString();
                threeBuyButton.Content = $"${Math.Round(three.CurrentPrice, 1)} {Resources["buy"]}";
                threeProgBar.Maximum = three.TimeMs * 1000;
                threeDurationTxt.Text = $"00:00:0{three.TimeMs}";
                //4

                //5

                //6

                //7

                //8

                //9

                //10
            }
            else if (number == "one")
            {
                oneUpgradeCountTxt.Text = one.UpgradeCount.ToString();
                oneMoneyTxt.Text = Math.Round((one.UpgradeCount * one.DefaultMoney), 1).ToString();
                oneBuyButton.Content = $"${Math.Round(one.CurrentPrice, 1)} {Resources["buy"]}";
                oneProgBar.Maximum = one.TimeMs * 1000;
                oneDurationTxt.Text = $"00:00:0{one.TimeMs}";
            }
            else if (number == "two")
            {
                twoUpgradeCountTxt.Text = two.UpgradeCount.ToString();
                twoMoneyTxt.Text = Math.Round((two.UpgradeCount * two.DefaultMoney), 1).ToString();
                twoBuyButton.Content = $"${Math.Round(two.CurrentPrice, 1)} {Resources["buy"]}";
                twoProgBar.Maximum = two.TimeMs * 1000;
                twoDurationTxt.Text = $"00:00:0{two.TimeMs}";
            }
            else if (number == "three")
            {
                threeUpgradeCountTxt.Text = three.UpgradeCount.ToString();
                threeMoneyTxt.Text = Math.Round((three.UpgradeCount * three.DefaultMoney), 1).ToString();
                threeBuyButton.Content = $"${Math.Round(three.CurrentPrice, 1)} {Resources["buy"]}";
                threeProgBar.Maximum = three.TimeMs * 1000;
                threeDurationTxt.Text = $"00:00:0{three.TimeMs}";
            }
        }
        #endregion
    }
}
