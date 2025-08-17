using CryptoViewer.UI.Wpf.ViewModels;
using System.Windows.Controls;

namespace CryptoViewer.UI.Wpf.Views.Pages
{
    /// <summary>
    /// Interaction logic for AssetDetailPage.xaml
    /// </summary>
    public partial class AssetDetailPage : Page
    {
        public AssetDetailPage(AssetDetailViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
