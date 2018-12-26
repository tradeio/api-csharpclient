namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents information about trading pair (symbol).
    /// </summary>
    public class PairInfo
    {
        /// <summary>
        /// Gets or sets trading pairs symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets symbol status (active, passive, etc).
        /// </summary>
        public SymbolStatus Status { get; set; }

        /// <summary>
        /// Gets or sets description of the symbol.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets base asset of the symbol.
        /// </summary>
        public string BaseAsset { get; set; }

        /// <summary>
        /// Gets or sets base asset precision (number of digits after floating point).
        /// </summary>
        public int BaseAssetPrecision { get; set; }

        /// <summary>
        /// Gets or sets quote asset of the symbol.
        /// </summary>
        public string QuoteAsset { get; set; }

        /// <summary>
        /// Gets or sets base asset precision (number of digits after floating point).
        /// </summary>
        public int QuoteAssetPrecision { get; set; }
    }
}
