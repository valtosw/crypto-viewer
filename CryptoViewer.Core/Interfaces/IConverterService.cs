namespace CryptoViewer.Core.Interfaces
{
    public interface IConverterService
    {
        Task<decimal> ConvertAsync(string fromSymbol, string toSymbol, decimal amount, CancellationToken cancellationToken = default);
    }
}
