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

        private void btnShopPage_Click(object sender, RoutedEventArgs e)
        {
            SetGameFromDb();
            this.NavigationService.Navigate(new ShopPage());
        }

        public async void Refresh(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(200);
                OneRefresh();
                TwoRefresh();
                ThreeRefresh();
                FourRefresh();
                FiveRefresh();
                SixRefresh();
                SevenRefresh();
                EightRefresh();
                NineRefresh();
                TenRefresh();
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
                twoProgBar.Value = 0;
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
                threeProgBar.Value = 0;
            }
        }
        private void FourRefresh()
        {
            fourProgBar.Value += 200;
            fourMoneyTxt.Text = (four.UpgradeCount * four.DefaultMoney).ToString();

            if (!(money >= four.CurrentPrice))
                fourBuyButton.IsEnabled = false;
            else
                fourBuyButton.IsEnabled = true;

            if (fourProgBar.Value >= (four.TimeMs * 1000) && four.Manager)
            {
                money = (four.UpgradeCount * four.DefaultMoney) + money;
                MoneyWriter();
                fourProgBar.Value = 0;
            }
        }
        private void FiveRefresh()
        {
            fiveProgBar.Value += 200;
            fiveMoneyTxt.Text = (five.UpgradeCount * five.DefaultMoney).ToString();

            if (!(money >= five.CurrentPrice))
                fiveBuyButton.IsEnabled = false;
            else
                fiveBuyButton.IsEnabled = true;

            if (fiveProgBar.Value >= (five.TimeMs * 1000) && five.Manager)
            {
                money = (five.UpgradeCount * five.DefaultMoney) + money;
                MoneyWriter();
                fiveProgBar.Value = 0;
            }
        }
        private void SixRefresh()
        {
            sixProgBar.Value += 200;
            sixMoneyTxt.Text = (six.UpgradeCount * six.DefaultMoney).ToString();

            if (!(money >= six.CurrentPrice))
                sixBuyButton.IsEnabled = false;
            else
                sixBuyButton.IsEnabled = true;

            if (sixProgBar.Value >= (six.TimeMs * 1000) && six.Manager)
            {
                money = (six.UpgradeCount * six.DefaultMoney) + money;
                MoneyWriter();
                sixProgBar.Value = 0;
            }
        }
        private void SevenRefresh()
        {
            sevenProgBar.Value += 200;
            sevenMoneyTxt.Text = (seven.UpgradeCount * seven.DefaultMoney).ToString();

            if (!(money >= seven.CurrentPrice))
                sevenBuyButton.IsEnabled = false;
            else
                sevenBuyButton.IsEnabled = true;

            if (sevenProgBar.Value >= (seven.TimeMs * 1000) && seven.Manager)
            {
                money = (seven.UpgradeCount * seven.DefaultMoney) + money;
                MoneyWriter();
                sevenProgBar.Value = 0;
            }
        }
        private void EightRefresh()
        {
            eightProgBar.Value += 200;
            eightMoneyTxt.Text = (eight.UpgradeCount * eight.DefaultMoney).ToString();

            if (!(money >= eight.CurrentPrice))
                eightBuyButton.IsEnabled = false;
            else
                eightBuyButton.IsEnabled = true;

            if (eightProgBar.Value >= (eight.TimeMs * 1000) && eight.Manager)
            {
                money = (eight.UpgradeCount * eight.DefaultMoney) + money;
                MoneyWriter();
                eightProgBar.Value = 0;
            }
        }
        private void NineRefresh()
        {
            nineProgBar.Value += 200;
            nineMoneyTxt.Text = (nine.UpgradeCount * nine.DefaultMoney).ToString();

            if (!(money >= nine.CurrentPrice))
                nineBuyButton.IsEnabled = false;
            else
                nineBuyButton.IsEnabled = true;

            if (nineProgBar.Value >= (nine.TimeMs * 1000) && nine.Manager)
            {
                money = (nine.UpgradeCount * nine.DefaultMoney) + money;
                MoneyWriter();
                nineProgBar.Value = 0;
            }
        }
        private void TenRefresh()
        {
            tenProgBar.Value += 200;
            tenMoneyTxt.Text = (ten.UpgradeCount * ten.DefaultMoney).ToString();

            if (!(money >= ten.CurrentPrice))
                tenBuyButton.IsEnabled = false;
            else
                tenBuyButton.IsEnabled = true;

            if (tenProgBar.Value >= (ten.TimeMs * 1000) && three.Manager)
            {
                money = (ten.UpgradeCount * ten.DefaultMoney) + money;
                MoneyWriter();
                tenProgBar.Value = 0;
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

        private void fourProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (fourProgBar.Value == (three.TimeMs * 1000))
            {
                money = (four.UpgradeCount * four.DefaultMoney) + money;
                MoneyWriter();
                fourProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Hazır değil");
            }
        }

        private void fiveProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (fiveProgBar.Value == (five.TimeMs * 1000))
            {
                money = (five.UpgradeCount * five.DefaultMoney) + money;
                MoneyWriter();
                fiveProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Hazır değil");
            }
        }

        private void sixProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sixProgBar.Value == (six.TimeMs * 1000))
            {
                money = (six.UpgradeCount * six.DefaultMoney) + money;
                MoneyWriter();
                sixProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Hazır değil");
            }
        }

        private void sevenProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sevenProgBar.Value == (seven.TimeMs * 1000))
            {
                money = (seven.UpgradeCount * seven.DefaultMoney) + money;
                MoneyWriter();
                sevenProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Hazır değil");
            }
        }
        private void eightProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (eightProgBar.Value == (eight.TimeMs * 1000))
            {
                money = (eight.UpgradeCount * eight.DefaultMoney) + money;
                MoneyWriter();
                eightProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Hazır değil");
            }
        }

        private void nineProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (nineProgBar.Value == (nine.TimeMs * 1000))
            {
                money = (nine.UpgradeCount * nine.DefaultMoney) + money;
                MoneyWriter();
                nineProgBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Hazır değil");
            }
        }

        private void tenProgBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (tenProgBar.Value == (ten.TimeMs * 1000))
            {
                money = (ten.UpgradeCount * ten.DefaultMoney) + money;
                MoneyWriter();
                tenProgBar.Value = 0;
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

        private void fourBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= four.CurrentPrice)
            {
                four.UpgradeCount += 1;
                money = money - four.CurrentPrice;
                four.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("four");
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void fiveBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= five.CurrentPrice)
            {
                five.UpgradeCount += 1;
                money = money - five.CurrentPrice;
                five.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("five");
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sixBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= six.CurrentPrice)
            {
                six.UpgradeCount += 1;
                money = money - six.CurrentPrice;
                six.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("six");
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void sevenBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= seven.CurrentPrice)
            {
                seven.UpgradeCount += 1;
                money = money - seven.CurrentPrice;
                seven.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("seven");
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void eightBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= eight.CurrentPrice)
            {
                eight.UpgradeCount += 1;
                money = money - eight.CurrentPrice;
                eight.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("eight");
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void nineBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= nine.CurrentPrice)
            {
                nine.UpgradeCount += 1;
                money = money - nine.CurrentPrice;
                nine.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("nine");
            }
            else
            {
                MessageBox.Show(Resources["notEnoughMoney"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void tenBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= ten.CurrentPrice)
            {
                ten.UpgradeCount += 1;
                money = money - ten.CurrentPrice;
                ten.CurrentPrice *= 1.21;
                MoneyWriter();
                ChangeProperties("ten");
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
            {
                ChangePropOne();
                ChangePropTwo();
                ChangePropThree();
                ChangePropFour();
                ChangePropFive();
                ChangePropSix();
                ChangePropSeven();
                ChangePropEight();
                ChangePropNine();
                ChangePropTen();
            }
            else if (number == "one")
                ChangePropOne();
            else if (number == "two")
                ChangePropTwo();
            else if (number == "three")
                ChangePropThree();
            else if (number == "four")
                ChangePropFour();
            else if (number == "five")
                ChangePropFive();
            else if (number == "six")
                ChangePropSix();
            else if (number == "seven")
                ChangePropSeven();
            else if (number == "eight")
                ChangePropEight();
            else if (number == "nine")
                ChangePropNine();
            else if (number == "ten")
                ChangePropTen();
            else
                MessageBox.Show("Eyüp kendinde misin ChangeProperties'e yanlış bir şey yazdın?? \n \n Yazdığın şey: " + number);
        }


        //Buradan aşağısı garbage (bir türlü başka çözüm bulamadım)
        private void ChangePropTen()
        {
            tenUpgradeCountTxt.Text = ten.UpgradeCount.ToString();
            tenMoneyTxt.Text = Math.Round((ten.UpgradeCount * ten.DefaultMoney), 1).ToString();
            tenBuyButton.Content = $"${Math.Round(ten.CurrentPrice, 1)} {Resources["buy"]}";
            tenProgBar.Maximum = ten.TimeMs * 1000;
            tenDurationTxt.Text = $"{ten.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropNine()
        {
            nineUpgradeCountTxt.Text = nine.UpgradeCount.ToString();
            nineMoneyTxt.Text = Math.Round((nine.UpgradeCount * nine.DefaultMoney), 1).ToString();
            nineBuyButton.Content = $"${Math.Round(nine.CurrentPrice, 1)} {Resources["buy"]}";
            nineProgBar.Maximum = nine.TimeMs * 1000;
            nineDurationTxt.Text = $"{nine.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropEight()
        {
            eightUpgradeCountTxt.Text = eight.UpgradeCount.ToString();
            eightMoneyTxt.Text = Math.Round((eight.UpgradeCount * eight.DefaultMoney), 1).ToString();
            eightBuyButton.Content = $"${Math.Round(eight.CurrentPrice, 1)} {Resources["buy"]}";
            eightProgBar.Maximum = eight.TimeMs * 1000;
            eightDurationTxt.Text = $"{eight.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropSeven()
        {
            sevenUpgradeCountTxt.Text = seven.UpgradeCount.ToString();
            sevenMoneyTxt.Text = Math.Round((seven.UpgradeCount * seven.DefaultMoney), 1).ToString();
            sevenBuyButton.Content = $"${Math.Round(seven.CurrentPrice, 1)} {Resources["buy"]}";
            sevenProgBar.Maximum = seven.TimeMs * 1000;
            sevenDurationTxt.Text = $"{seven.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropSix()
        {
            sixUpgradeCountTxt.Text = six.UpgradeCount.ToString();
            sixMoneyTxt.Text = Math.Round((six.UpgradeCount * six.DefaultMoney), 1).ToString();
            sixBuyButton.Content = $"${Math.Round(six.CurrentPrice, 1)} {Resources["buy"]}";
            sixProgBar.Maximum = six.TimeMs * 1000;
            sixDurationTxt.Text = $"{six.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropFive()
        {
            fiveUpgradeCountTxt.Text = five.UpgradeCount.ToString();
            fiveMoneyTxt.Text = Math.Round((five.UpgradeCount * five.DefaultMoney), 1).ToString();
            fiveBuyButton.Content = $"${Math.Round(five.CurrentPrice, 1)} {Resources["buy"]}";
            fiveProgBar.Maximum = five.TimeMs * 1000;
            fiveDurationTxt.Text = $"{five.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropFour()
        {
            fourUpgradeCountTxt.Text = four.UpgradeCount.ToString();
            fourMoneyTxt.Text = Math.Round((four.UpgradeCount * four.DefaultMoney), 1).ToString();
            fourBuyButton.Content = $"${Math.Round(four.CurrentPrice, 1)} {Resources["buy"]}";
            fourProgBar.Maximum = four.TimeMs * 1000;
            fourDurationTxt.Text = $"{four.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropThree()
        {
            threeUpgradeCountTxt.Text = three.UpgradeCount.ToString();
            threeMoneyTxt.Text = Math.Round((three.UpgradeCount * three.DefaultMoney), 1).ToString();
            threeBuyButton.Content = $"${Math.Round(three.CurrentPrice, 1)} {Resources["buy"]}";
            threeProgBar.Maximum = three.TimeMs * 1000;
            threeDurationTxt.Text = $"{three.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropTwo()
        {
            twoUpgradeCountTxt.Text = two.UpgradeCount.ToString();
            twoMoneyTxt.Text = Math.Round((two.UpgradeCount * two.DefaultMoney), 1).ToString();
            twoBuyButton.Content = $"${Math.Round(two.CurrentPrice, 1)} {Resources["buy"]}";
            twoProgBar.Maximum = two.TimeMs * 1000;
            twoDurationTxt.Text = $"{two.TimeMs} {Resources["shortSecond"]}";
        }

        private void ChangePropOne()
        {
            oneUpgradeCountTxt.Text = one.UpgradeCount.ToString();
            oneMoneyTxt.Text = Math.Round((one.UpgradeCount * one.DefaultMoney), 1).ToString();
            oneBuyButton.Content = $"${Math.Round(one.CurrentPrice, 1)} {Resources["buy"]}";
            oneProgBar.Maximum = one.TimeMs * 1000;
            oneDurationTxt.Text = $"{one.TimeMs} {Resources["shortSecond"]}";
        }
        #endregion
    }
}
