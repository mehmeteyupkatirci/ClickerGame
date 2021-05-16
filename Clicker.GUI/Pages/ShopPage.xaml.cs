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
        public ShopPage()
        {
            InitializeComponent();
            GetAllImprovement();
            MenajerToggles();
        }

        private void btnGamePage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GamePage());
        }

        #region Menajer
        private void btnOneMenajer_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnTwoMenajer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTreeMenajer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFourMenajer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFiveMenajer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSixMenajer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSevenMenajer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEightMenajer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNineMenajer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTenMenajer_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Price
        private void btnOnePrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTwoPrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTreePrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFourPrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFivePrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSixPrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSevenPrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEightPrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNinePrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTenPrice_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Times
        private void btnOneTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTwoTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTreeTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFourTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFiveTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSixTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSevenTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEightTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNineTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTenTime_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Helpers
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

        private void MenajerToggles()
        {
            if (one.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (two.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (three.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (four.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (five.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (six.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (seven.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (eight.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (nine.Manager)
                btnOneMenajer.IsEnabled = false;
            else if (ten.Manager)
                btnOneMenajer.IsEnabled = false;
        }
        #endregion
    }
}
