﻿using Clicker.DataAccess.Abstract;
using Clicker.DataAccess.Concrete.EntityFramework;
using Clicker.Entities.Concrete;
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
    public partial class GamePage : Page
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        EfImprovement _improvementDal = new EfImprovement();

        private double money = 20;
        private double oneDefaultMoney = 5;
        private double oneCurrentPrice = 10;

        public GamePage()
        {
            InitializeComponent();

            FirstGetUserData();
            //oneUpgradeCountTxt.Text = 1.ToString();
            RefreshFirstProgress(_cancellationTokenSource.Token);
            moneyTxt.Text = money.ToString();
        }

        private void FirstGetUserData()
        {
            //Improvement ımprovement = new Improvement() {Id = "test", StartPrice = 2, CurrentPrice = 1, Manager = true, TimeMs = 20, UpgradeCount = 23};
            //_improvementDal.Add(ımprovement);
            var improvement = _improvementDal.Get(x => x.Id == "first");
            oneUpgradeCountTxt.Text = improvement.UpgradeCount.ToString();
            oneCurrentPrice = improvement.CurrentPrice;
            oneDefaultMoney = improvement.StartPrice;
            oneProgBar.Maximum = improvement.TimeMs * 1000;
            oneDurationTxt.Text = $"00:00:0{improvement.TimeMs}";
            oneMoneyTxt.Text = (Convert.ToDouble(oneUpgradeCountTxt.Text) * oneDefaultMoney).ToString();
        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show(Resources["back2HomePageMB"].ToString(), Resources["appFullName"].ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);
            SetDb2LastChanges();
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomePage());
            }
        }

        public void SetDb2LastChanges()
        {
            var improvement = _improvementDal.Get(x => x.Id == "first");
            improvement.CurrentPrice = oneCurrentPrice;
            improvement.UpgradeCount = Convert.ToInt32(oneUpgradeCountTxt.Text);
            _improvementDal.Update(improvement);
        }

        public async void RefreshFirstProgress(CancellationToken cancellationToken)
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
