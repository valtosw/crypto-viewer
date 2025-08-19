using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;
using CryptoViewer.UI.Wpf.Services.Interfaces;
using CryptoViewer.UI.Wpf.Views.Pages;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CryptoViewer.UI.Wpf.ViewModels
{
    public class SearchViewModel(ISearchService searchService, INavigationService navigationService) : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Asset> SearchResults { get; } = [];

        private string _searchQuery = string.Empty;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged();
                }
            }
        }

        private Asset? _selectedAsset;
        public Asset? SelectedAsset
        {
            get => _selectedAsset;
            set
            {
                if (_selectedAsset != value)
                {
                    _selectedAsset = value;
                    OnPropertyChanged();

                    if (_selectedAsset is not null)
                    {
                        navigationService.NavigateTo<AssetDetailPage>(_selectedAsset);
                    }
                }
            }
        }

        public async Task PerformSearchAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                SearchResults.Clear();
                return;
            }

            try
            {
                var results = await searchService.SearchAsync(SearchQuery, CancellationToken.None);

                SearchResults.Clear();

                foreach (var asset in results)
                {
                    SearchResults.Add(asset);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Search failed: {ex.Message}");
            }
        }

        private void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchQuery)));
        }
    }
}
