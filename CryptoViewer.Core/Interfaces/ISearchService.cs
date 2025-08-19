using CryptoViewer.Core.Models;

namespace CryptoViewer.Core.Interfaces
{
    public interface ISearchService
    {
        Task<IReadOnlyList<Asset>> SearchAsync(string query, CancellationToken cancellationToken = default);
    }
}
