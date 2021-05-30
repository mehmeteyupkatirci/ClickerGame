using Clicker.Business.Concrete;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        ConfigurationDataService _configurationDataService = new ConfigurationDataService();
        ImprovementService _improvementService = new ImprovementService();

        public HomePage()
        {
            InitializeComponent();
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            var initConfigurationData = _configurationDataService.InitConfigurationData();
            if (initConfigurationData)
            {
                var initImprovement = _improvementService.InitImprovements();
                if (initImprovement)
                    MessageBox.Show("Kurulum başarıyla tamamlandı");
                else
                    MessageBox.Show("Kurulum gerçekleştirilirken bir sorunla karşılaşıldı");
            }
            this.NavigationService.Navigate(new GamePage());
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage());
        }
    }
}
