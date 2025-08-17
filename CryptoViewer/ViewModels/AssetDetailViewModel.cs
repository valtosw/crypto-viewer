using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;
using CryptoViewer.UI.Wpf.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public class AssetDetailViewModel(IMarketDataService marketDataService) : INavigable
    {
        public Asset? Asset { get; set; }

        public ObservableCollection<Market> Markets { get; } = [];

        public async Task OnNavigatedTo(object parameter)
        {
            if (parameter is Asset asset)
            {
                await LoadMarketsAsync(asset);
            }
        }

        public async Task LoadMarketsAsync(Asset asset)
        {
            Asset = asset;
            Markets.Clear();

            var markets = await marketDataService.GetMarketsAsync(asset.Id);

            foreach (var market in markets)
            {
                Markets.Add(market);
            }
        }
    }
}
