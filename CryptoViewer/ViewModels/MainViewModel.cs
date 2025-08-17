using CryptoViewer.Core.Interfaces;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public class MainViewModel : AssetsViewModelBase
    {
        public MainViewModel(IMarketDataService marketDataService)
            : base(marketDataService)
        {
            _ = LoadAssetsAsync(100);
        }
    }
}
