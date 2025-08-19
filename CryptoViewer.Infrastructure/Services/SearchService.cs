using CryptoViewer.Core.DTOs;
using CryptoViewer.Core.Interfaces;
using CryptoViewer.Core.Models;
using CryptoViewer.Infrastructure.Http;

namespace CryptoViewer.Infrastructure.Services
{
    public class SearchService(ApiClient apiClient) : ISearchService
    {
        public async Task<IReadOnlyList<Asset>> SearchAsync(string query, CancellationToken cancellationToken = default)
        {
            var path = $"assets?search={query}";
            var result = await apiClient.GetAsync<ApiListResponse<Asset>>(path, cancellationToken);

            return result?.Data ?? [];
        }
    }
}
