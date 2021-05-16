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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        ImprovementService _improvementService = new ImprovementService();

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
            var result = _improvementService.DeleteAllImprovement();
            if (!result)
            {
                _improvementService.DeleteAllImprovement();
            }
        }
    }
}
