using CryptoViewer.Core.Interfaces;

namespace CryptoViewer.Infrastructure.Services
{
    public class ConverterService(IMarketDataService marketDataService) : IConverterService
    {
        public async Task<decimal> ConvertAsync(string fromSymbol, string toSymbol, decimal amount, CancellationToken cancellationToken = default)
        {
            var fromAsset = await marketDataService.GetAssetAsync(fromSymbol, cancellationToken);
            var toAsset = await marketDataService.GetAssetAsync(toSymbol, cancellationToken);

            if (fromAsset?.PriceUsd is null || toAsset?.PriceUsd is null)
            {
                throw new InvalidOperationException("Null price is present");
            }

            var usdValue = amount * fromAsset.PriceUsd.Value;
            var convertedValue = usdValue / toAsset.PriceUsd.Value;

            return convertedValue;
        }
    }
}
