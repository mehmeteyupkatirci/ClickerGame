using Clicker.Business.Concrete;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Clicker.GUI.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        ImprovementService _improvementService = new ImprovementService();
        ConfigurationDataService _configurationDataService = new ConfigurationDataService();
        public bool soundEffects = true;

        public SettingsPage()
        {
            InitializeComponent();
            var config = _configurationDataService.GetConfigurationData("sound_effects");
            if (config.Value == "true")
            {
                btnSoundOpen.Visibility = Visibility.Visible;
                btnSoundClose.Visibility = Visibility.Collapsed;
            }
            else if (config.Value == "false")
            {
                btnSoundClose.Visibility = Visibility.Collapsed;
                btnSoundOpen.Visibility = Visibility.Visible;
            }
        }
        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }

        private void btnDeleteAllRecords_Click(object sender, RoutedEventArgs e)
        {
            var response = MessageBox.Show("Oyunun Tüm Datası Silinecek Emin Misiniz?", "Clicker Game Bilgilendirme", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == MessageBoxResult.Yes)
            {
                _improvementService.DeleteAllImprovement();
                _configurationDataService.DeleteAllConfiguraitonsData();
                MessageBox.Show("Silindi");
            }
        }

        private void btnSoundOpen_Click(object sender, RoutedEventArgs e)
        {
            btnSoundOpen.Visibility = Visibility.Collapsed;
            btnSoundClose.Visibility = Visibility.Visible;
            _configurationDataService.UpdateConfigurationData("sound_effects", "true");
        }

        private void btnSoundClose_Click(object sender, RoutedEventArgs e)
        {
            btnSoundClose.Visibility = Visibility.Collapsed;
            btnSoundOpen.Visibility = Visibility.Visible;
            _configurationDataService.UpdateConfigurationData("sound_effects", "false");
        }
    }
}
