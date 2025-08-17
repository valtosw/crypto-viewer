using CryptoViewer.Core.Models;
using CryptoViewer.UI.Wpf.Services.Interfaces;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public class AssetDetailViewModel : INavigable
    {
        public Asset? Asset { get; set; }

        public void OnNavigatedTo(object parameter)
        {
            if (parameter is Asset asset)
            {
                Asset = asset;
            }
        }
    }
}
