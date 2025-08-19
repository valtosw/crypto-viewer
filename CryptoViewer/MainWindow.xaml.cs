using CryptoViewer.UI.Wpf.Services.Interfaces;
using CryptoViewer.UI.Wpf.Views.Pages;
using System.Windows;

namespace CryptoViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly INavigationService _navigationService;

        public MainWindow(INavigationService navigationService)
        {
            InitializeComponent();

            _navigationService = navigationService;
            _navigationService.SetFrame(MainFrame);
            _navigationService.NavigateTo<DashboardPage>();
        }

        private void NavigateToDashboard(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<DashboardPage>();
        }

        private void NavigateToSearch(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<SearchPage>();
        }
    }
}