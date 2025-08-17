using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;
using CryptoViewer.UI.Wpf.Services.Interfaces;
using CryptoViewer.UI.Wpf.Views.Pages;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public class DashboardViewModel : AssetsViewModelBase
    {
        private readonly INavigationService _navigationService;
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

        public DashboardViewModel(IMarketDataService marketDataService, INavigationService navigationService)
            : base(marketDataService)
        {
            _navigationService = navigationService;

            _ = LoadAssetsAsync(50);
        }

        private void OnAssetSelected(Asset asset)
        {
            _navigationService.NavigateTo<AssetDetailPage>(asset);
        }
    }
}

