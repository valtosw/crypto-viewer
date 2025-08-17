using CryptoViewer.UI.Wpf.ViewModels;
using System.Windows.Controls;

namespace CryptoViewer.UI.Wpf.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage(DashboardViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
