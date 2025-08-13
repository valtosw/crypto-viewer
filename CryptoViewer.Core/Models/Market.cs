namespace CryptoViewer.Core.Models
{
    public class Market
    {
        public required string ExchangeId { get; set; }
        public int Rank { get; set; }
        public required string BaseSymbol { get; set; }
        public required string BaseId { get; set; }
        public required string QuoteSymbol { get; set; }
        public required string QuoteId { get; set; }
        public decimal? PriceQuote { get; set; }
        public decimal? PriceUsd { get; set; }
        public decimal? VolumeUsd24Hr { get; set; }
        public decimal? PercentExchangeVolume { get; set; }
        public decimal? TradesCount24Hr { get; set; }
    }
}
