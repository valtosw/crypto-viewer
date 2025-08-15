using CryptoViewer.Core.DTOs;
using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;
using CryptoViewer.Infrastructure.Http;

namespace CryptoViewer.Infrastructure.Services
{
    public class MarketDataService(ApiClient apiClient) : IMarketDataService
    {
        public async Task<Asset?> GetAssetAsync(string idOrSymbol, CancellationToken cancellationToken = default)
        {
            var path = $"assets/{idOrSymbol}";
            var result = await apiClient.GetAsync<ApiSingleResponse<Asset?>>(path, cancellationToken);

            return result?.Data;
        }

        public async Task<IReadOnlyList<Market>> GetMarketsAsync(string assetId, CancellationToken cancellationToken = default)
        {
            var path = $"markets?assetId={assetId}";
            var result = await apiClient.GetAsync<ApiListResponse<Market>>(path, cancellationToken);

            return result?.Data ?? [];
        }

        public async Task<IReadOnlyList<Asset>> GetTopAssetsAsync(int limit = 100, CancellationToken cancellationToken = default)
        {
            var path = $"assets?limit={limit}";
            var result = await apiClient.GetAsync<ApiListResponse<Asset>>(path, cancellationToken);

            return result?.Data ?? [];
        }
    }
}
