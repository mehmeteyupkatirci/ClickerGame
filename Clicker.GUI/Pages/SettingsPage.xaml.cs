using Clicker.Business.Concrete;
using System.Windows;
using System.Windows.Controls;

namespace Clicker.GUI.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        ImprovementService _improvementService = new ImprovementService();
        ConfigurationDataService _configurationDataService = new ConfigurationDataService();


        public SettingsPage()
        {
            InitializeComponent();
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
    }
}
