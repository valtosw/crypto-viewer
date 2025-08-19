using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;
using CryptoViewer.UI.Wpf.Services.Interfaces;
using CryptoViewer.UI.Wpf.Views.Pages;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public class DashboardViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IMarketDataService _marketDataService;

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Asset> Assets { get; } = [];

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
        {
            _navigationService = navigationService;
            _marketDataService = marketDataService;

            _ = LoadAssetsAsync(50);
        }

        public async Task LoadAssetsAsync(int limit, CancellationToken cancellationToken = default)
        {
            var assets = await _marketDataService.GetTopAssetsAsync(limit, cancellationToken);

            Assets.Clear();

            foreach (var asset in assets)
            {
                Assets.Add(asset);
            }
        }

        public void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnAssetSelected(Asset asset)
        {
            _navigationService.NavigateTo<AssetDetailPage>(asset);
        }
    }
}

