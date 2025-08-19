using CryptoViewer.UI.Wpf.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace CryptoViewer.UI.Wpf.Views.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        private readonly SearchViewModel _viewModel;

        public SearchPage(SearchViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
        }

        private async void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                await _viewModel.PerformSearchAsync();
            }
        }
    }
}
