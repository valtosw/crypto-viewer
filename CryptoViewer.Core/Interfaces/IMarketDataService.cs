using CryptoViewer.Core.Models;

namespace CryptoViewer.Core.Interfaces
{
    public interface IMarketDataService
    {
        Task<IReadOnlyList<Asset>> GetTopAssetsAsync(int? limit = null, CancellationToken cancellationToken = default);
        Task<Asset?> GetAssetAsync(string idOrSymbol, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Market>> GetMarketsAsync(string assetId, CancellationToken cancellationToken = default);
    }
}
