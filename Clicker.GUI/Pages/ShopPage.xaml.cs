using Clicker.Business.Concrete;
using Clicker.Entities.Concrete;
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

namespace Clicker.GUI.Pages
{
    /// <summary>
    /// Interaction logic for ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        ImprovementService _improvementService = new ImprovementService();
        ConfigurationDataService _configurationDataService = new ConfigurationDataService();

        private Improvement one, two, three, four, five, six, seven, eight, nine, ten;
        private double money = 0;

        public ShopPage()
        {
            InitializeComponent();
            GetAllImprovement();
            BuyEvent();
        }

        private void BuyEvent()
        {
            MoneyWriter();
            MenajerToggles();
            PriceToggles();
            TimeToggles();
        }

        private void btnGamePage_Click(object sender, RoutedEventArgs e)
        {
            SetAllImrpovement();
            this.NavigationService.Navigate(new GamePage());
        }

        #region Menajer
        private void btnOneMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= one.ManagerCost;
            BuyEvent();
            one.Manager = true;
            btnOneMenajer.IsEnabled = false;
        }

        private void btnTwoMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= two.ManagerCost;
            BuyEvent();
            two.Manager = true;
            btnTwoMenajer.IsEnabled = false;
        }

        private void btnTreeMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= three.ManagerCost;
            BuyEvent();
            three.Manager = true;
            btnTreeMenajer.IsEnabled = false;
        }

        private void btnFourMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= four.ManagerCost;
            BuyEvent();
            four.Manager = true;
            btnFourMenajer.IsEnabled = false;
        }

        private void btnFiveMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= five.ManagerCost;
            BuyEvent();
            five.Manager = true;
            btnFiveMenajer.IsEnabled = false;
        }

        private void btnSixMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= six.ManagerCost;
            BuyEvent();
            six.Manager = true;
            btnSixMenajer.IsEnabled = false;
        }

        private void btnSevenMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= seven.ManagerCost;
            BuyEvent();
            seven.Manager = true;
            btnSevenMenajer.IsEnabled = false;
        }

        private void btnEightMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= eight.ManagerCost;
            BuyEvent();
            eight.Manager = true;
            btnEightMenajer.IsEnabled = false;
        }

        private void btnNineMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= nine.ManagerCost;
            BuyEvent();
            nine.Manager = true;
            btnNineMenajer.IsEnabled = false;
        }

        private void btnTenMenajer_Click(object sender, RoutedEventArgs e)
        {
            money -= ten.ManagerCost;
            BuyEvent();
            ten.Manager = true;
            btnTenMenajer.IsEnabled = false;
        }
        #endregion

        #region Price
        private void btnOnePrice_Click(object sender, RoutedEventArgs e)
        {
            money -= one.PriceCost;
            one.PriceCost = one.PriceCost * 3;
            BuyEvent();
            one.DefaultMoney = one.DefaultMoney*2;
        }

        private void btnTwoPrice_Click(object sender, RoutedEventArgs e)
        {
            money -= two.PriceCost;
            two.PriceCost = two.PriceCost * 3;
            BuyEvent();
            two.DefaultMoney = two.DefaultMoney * 2;
        }

        private void btnTreePrice_Click(object sender, RoutedEventArgs e)
        {
            money -= three.PriceCost;
            three.PriceCost = three.PriceCost * 3;
            BuyEvent();
            three.DefaultMoney = three.DefaultMoney * 2;
        }

        private void btnFourPrice_Click(object sender, RoutedEventArgs e)
        {
            money -= four.PriceCost;
            four.PriceCost = four.PriceCost * 3;
            BuyEvent();
            four.DefaultMoney = four.DefaultMoney * 2;
        }

        private void btnFivePrice_Click(object sender, RoutedEventArgs e)
        {
            money -= five.PriceCost;
            five.PriceCost = five.PriceCost * 3;
            BuyEvent();
            five.DefaultMoney = five.DefaultMoney * 2;
        }

        private void btnSixPrice_Click(object sender, RoutedEventArgs e)
        {
            money -= six.PriceCost;
            six.PriceCost = six.PriceCost * 3;
            BuyEvent();
            six.DefaultMoney = six.DefaultMoney * 2;
        }

        private void btnSevenPrice_Click(object sender, RoutedEventArgs e)
        {
            money -= seven.PriceCost;
            seven.PriceCost = seven.PriceCost * 3;
            BuyEvent();
            seven.DefaultMoney = seven.DefaultMoney * 2;
        }

        private void btnEightPrice_Click(object sender, RoutedEventArgs e)
        {
            money -= eight.PriceCost;
            eight.PriceCost = eight.PriceCost * 3;
            BuyEvent();
            eight.DefaultMoney = eight.DefaultMoney * 2;
        }

        private void btnNinePrice_Click(object sender, RoutedEventArgs e)
        {
            money -= nine.PriceCost;
            nine.PriceCost = nine.PriceCost * 3;
            BuyEvent();
            nine.DefaultMoney = nine.DefaultMoney * 2;
        }

        private void btnTenPrice_Click(object sender, RoutedEventArgs e)
        {
            money -= ten.PriceCost;
            ten.PriceCost = ten.PriceCost * 3;
            BuyEvent();
            ten.DefaultMoney = ten.DefaultMoney * 2;
        }

        #endregion

        #region Times
        private void btnOneTime_Click(object sender, RoutedEventArgs e)
        {
            money -= one.TimeCost;
            one.TimeCost = one.TimeCost * 3;
            one.TimeMs = one.TimeMs - 0.2;
            BuyEvent();
        }

        private void btnTwoTime_Click(object sender, RoutedEventArgs e)
        {
            money -= two.TimeCost;
            two.TimeCost = two.TimeCost * 3;
            two.TimeMs = two.TimeMs - 0.8;
            BuyEvent();
        }

        private void btnTreeTime_Click(object sender, RoutedEventArgs e)
        {
            money -= three.TimeCost;
            three.TimeCost = three.TimeCost * 3;
            three.TimeMs = three.TimeMs - 0.8;
            BuyEvent();
        }

        private void btnFourTime_Click(object sender, RoutedEventArgs e)
        {
            money -= four.TimeCost;
            four.TimeCost = four.TimeCost * 3;
            four.TimeMs = four.TimeMs - 0.8;
            BuyEvent();
        }

        private void btnFiveTime_Click(object sender, RoutedEventArgs e)
        {
            money -= five.TimeCost;
            five.TimeCost = five.TimeCost * 3;
            five.TimeMs = five.TimeMs - 0.8;
            BuyEvent();
        }

        private void btnSixTime_Click(object sender, RoutedEventArgs e)
        {
            money -= six.TimeCost;
            six.TimeCost = six.TimeCost * 3;
            six.TimeMs = six.TimeMs - 0.8;
            BuyEvent();
        }

        private void btnSevenTime_Click(object sender, RoutedEventArgs e)
        {
            money -= seven.TimeCost;
            seven.TimeCost = seven.TimeCost * 3;
            seven.TimeMs = seven.TimeMs - 0.8;
            BuyEvent();
        }

        private void btnEightTime_Click(object sender, RoutedEventArgs e)
        {
            money -= eight.TimeCost;
            eight.TimeCost = eight.TimeCost * 3;
            eight.TimeMs = eight.TimeMs - 0.8;
            BuyEvent();
        }

        private void btnNineTime_Click(object sender, RoutedEventArgs e)
        {
            money -= nine.TimeCost;
            nine.TimeCost = nine.TimeCost * 3;
            nine.TimeMs = nine.TimeMs - 0.8;
            BuyEvent();
        }

        private void btnTenTime_Click(object sender, RoutedEventArgs e)
        {
            money -= ten.TimeCost;
            ten.TimeCost = ten.TimeCost * 3;
            ten.TimeMs = ten.TimeMs - 0.8;
            BuyEvent();
        }
        #endregion

        #region Helpers
        private void MoneyWriter()
        {
            moneyTxt.Text = Math.Round(money, 1).ToString();
        }
        private void GetAllImprovement()
        {
            money = Convert.ToDouble(_configurationDataService.GetConfigurationData("money").Value);
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
            Convert.ToDouble(_configurationDataService.UpdateConfigurationData("money", money.ToString()));
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

        private void MenajerToggles()
        {
            if (!one.Manager && money > one.ManagerCost)
                btnOneMenajer.IsEnabled = true;
            if (!two.Manager && money > two.ManagerCost)
                btnTwoMenajer.IsEnabled = true;
            if (!three.Manager && money > three.ManagerCost)
                btnTreeMenajer.IsEnabled = true;
            if (!four.Manager && money > four.ManagerCost)
                btnFourMenajer.IsEnabled = true;
            if (!five.Manager && money > five.ManagerCost)
                btnFiveMenajer.IsEnabled = true;
            if (!six.Manager && money > six.ManagerCost)
                btnSixMenajer.IsEnabled = true;
            if (!seven.Manager && money > seven.ManagerCost)
                btnSevenMenajer.IsEnabled = true;
            if (!eight.Manager && money > eight.ManagerCost)
                btnEightMenajer.IsEnabled = true;
            if (!nine.Manager && money > nine.ManagerCost)
                btnNineMenajer.IsEnabled = true;
            if (!ten.Manager && money > ten.ManagerCost)
                btnTenMenajer.IsEnabled = true;
        }
        private void PriceToggles()
        {
            if (money > one.PriceCost)
                btnOnePrice.IsEnabled = true;
            else
                btnOnePrice.IsEnabled = false;
            if (money > two.PriceCost)
                btnTwoPrice.IsEnabled = true;
            else
                btnTwoPrice.IsEnabled = false;
            if (money > three.PriceCost)
                btnTreePrice.IsEnabled = true;
            else
                btnTreePrice.IsEnabled = false;
            if (money > four.PriceCost)
                btnFourPrice.IsEnabled = true;
            else
                btnFourPrice.IsEnabled = false;

            if (money > five.PriceCost)
                btnFivePrice.IsEnabled = true;
            else
                btnFivePrice.IsEnabled = false;

            if (money > six.PriceCost)
                btnSixPrice.IsEnabled = true;
            else
                btnSixPrice.IsEnabled = false;

            if (money > seven.PriceCost)
                btnSevenPrice.IsEnabled = true;
            else
                btnSevenPrice.IsEnabled = false;

            if (money > eight.PriceCost)
                btnEightPrice.IsEnabled = true;
            else
                btnEightPrice.IsEnabled = false;

            if (money > nine.PriceCost)
                btnNinePrice.IsEnabled = true;
            else
                btnNinePrice.IsEnabled = false;

            if (money > ten.PriceCost)
                btnTenPrice.IsEnabled = true;
            else
                btnTenPrice.IsEnabled = false;
        }
        private void TimeToggles()
        {
            if (money > one.TimeCost && one.TimeMs >= 1)
                btnOneTime.IsEnabled = true;
            else
                btnOneTime.IsEnabled = false;
            if (money > two.TimeCost && two.TimeMs >= 2)
                btnTwoTime.IsEnabled = true;
            else
                btnTwoTime.IsEnabled = false;
            if (money > three.TimeCost && three.TimeMs > 1)
                btnTreeTime.IsEnabled = true;
            else
                btnTreeTime.IsEnabled = false;
            if (money > four.TimeCost && four.TimeMs > 1)
                btnFourTime.IsEnabled = true;
            else
                btnFourTime.IsEnabled = false;
            if (money > five.TimeCost && five.TimeMs > 1)
                btnFiveTime.IsEnabled = true;
            else
                btnFiveTime.IsEnabled = false;
            if (money > six.TimeCost && six.TimeMs > 1)
                btnSixTime.IsEnabled = true;
            else
                btnSixTime.IsEnabled = false;
            if (money > seven.TimeCost && seven.TimeMs > 1)
                btnSevenTime.IsEnabled = true;
            else
                btnSevenTime.IsEnabled = false;
            if (money > eight.TimeCost && eight.TimeMs > 1)
                btnEightTime.IsEnabled = true;
            else
                btnEightTime.IsEnabled = false;
            if (money > nine.TimeCost && nine.TimeMs > 1)
                btnNineTime.IsEnabled = true;
            else
                btnNineTime.IsEnabled = false;
            if (money > ten.TimeCost && ten.TimeMs > 1)
                btnTenTime.IsEnabled = true;
            else
                btnTenTime.IsEnabled = false;
        }
        #endregion
    }
}
