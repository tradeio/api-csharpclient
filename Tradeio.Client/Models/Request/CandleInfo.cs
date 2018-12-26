namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents a candlestick.
    /// </summary>
    public class CandleInfo
    {
        /// <summary>
        /// Gets or sets associated symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets candlestick open time (in milliseconds).
        /// </summary>
        public long OpenTime { get; set; }

        /// <summary>
        /// Gets or sets candlestick close time (in milliseconds).
        /// </summary>
        public long CloseTime { get; set; }

        /// <summary>
        /// Gets or sets the open price.
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// Gets or sets the high price.
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// Gets or sets the low price.
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// Gets or sets the close price.
        /// </summary>
        public decimal Close{ get; set; }

        /// <summary>
        /// Gets or sets the quantity of the candlestick.
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// Gets or sets the number of performed trades.
        /// </summary>
        public long TradeCount { get; set; }
    }
}
