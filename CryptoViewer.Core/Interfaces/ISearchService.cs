using CryptoViewer.Core.Models;

namespace CryptoViewer.Core.Interfaces
{
    public interface ISearchService
    {
        Task<IReadOnlyList<Asset>> SearchAsync(string query, int limit = 10, CancellationToken cancellationToken = default);
    }
}
