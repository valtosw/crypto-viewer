using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public class DashboardViewModel : AssetsViewModelBase
    {
        private Asset? _selectedAsset;

        public Asset? SelectedAsset
        {
            get => _selectedAsset;
            set
            {
                if (_selectedAsset != value)
                {
                    _selectedAsset = value;

                    if (value is not null)
                    {
                        OnAssetSelected(value);
                    }
                }
            }
        }

        public DashboardViewModel(IMarketDataService marketDataService)
            : base(marketDataService)
        {
            _ = LoadAssetsAsync(50);
        }

        private void OnAssetSelected(Asset asset)
        {
            throw new NotImplementedException("Navigation to asset details is not implemented yet.");
        }
    }
}

