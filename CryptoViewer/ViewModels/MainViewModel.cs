using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IMarketDataService _marketDataService;

        public ObservableCollection<Asset> Assets { get; } = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel(IMarketDataService marketDataService)
        {
            _marketDataService = marketDataService;
            _ = LoadAssetsAsync();
        }

        protected void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task LoadAssetsAsync(CancellationToken cancellationToken = default)
        {
            var assets = await _marketDataService.GetTopAssetsAsync(100, cancellationToken);
            Assets.Clear();

            foreach (var asset in assets)
            {
                Assets.Add(asset);
            }
        }
    }
}
