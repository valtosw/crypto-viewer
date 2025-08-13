namespace CryptoViewer.Core.Models
{
    public class Asset
    {
        public required string Id { get; set; }
        public required string Symbol { get; set; }
        public required string Name { get; set; }
        public int Rank { get; set; }
        public decimal? Supply { get; set; }
        public decimal? MaxSupply { get; set; }
        public decimal? PriceUsd { get; set; }
        public decimal? ChangePercent24Hr { get; set; }
        public decimal? MarketCapUsd { get; set; }
        public decimal? VolumeUsd24Hr { get; set; }
    }
}
