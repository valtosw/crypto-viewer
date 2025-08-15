using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;

namespace CryptoViewer.Infrastructure.Services
{
    public class SearchService(IMarketDataService marketDataService) : ISearchService
    {
        public async Task<IReadOnlyList<Asset>> SearchAsync(string query, int limit = 50, CancellationToken cancellationToken = default)
        {
            var unfilteredResult = await marketDataService.GetTopAssetsAsync(limit, cancellationToken);

            return (IReadOnlyList<Asset>)unfilteredResult
                .Where(a => a.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                             a.Symbol.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                             a.Id.Contains(query, StringComparison.OrdinalIgnoreCase));
        }
    }
}
