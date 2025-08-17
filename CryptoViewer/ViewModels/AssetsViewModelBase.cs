using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public abstract class AssetsViewModelBase(IMarketDataService marketDataService)
    {
        protected readonly IMarketDataService _marketDataService = marketDataService;

        public ObservableCollection<Asset> Assets { get; } = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        protected async Task LoadAssetsAsync(int limit, CancellationToken cancellationToken = default)
        {
            var assets = await _marketDataService.GetTopAssetsAsync(limit, cancellationToken);

            Assets.Clear();

            foreach (var asset in assets)
            {
                Assets.Add(asset);
            }
        }

        protected void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
