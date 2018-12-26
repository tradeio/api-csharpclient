namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents a ticker.
    /// </summary>
    public class Ticker
    {
        /// <summary>
        /// Gets or sets associated symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the ticker's ask price.
        /// </summary>
        public decimal AskPrice { get; set; }

        /// <summary>
        /// Gets or sets the ticker's ask quantity.
        /// </summary>
        public decimal AskQty { get; set; }

        /// <summary>
        /// Gets or sets the ticker's bid price.
        /// </summary>
        public decimal BidPrice { get; set; }

        /// <summary>
        /// Gets or sets the ticker's bid quantity.
        /// </summary>
        public decimal BidQty { get; set; }

        /// <summary>
        /// Gets or sets the ticker's last price.
        /// </summary>
        public decimal LastPrice { get; set; }

        /// <summary>
        /// Gets or sets the ticker's last quantity.
        /// </summary>
        public decimal LastQty { get; set; }

        /// <summary>
        /// Gets or sets the ticker's volume.
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// Gets or sets the ticker's quote volume.
        /// </summary>
        public decimal QuoteVolume { get; set; }

        /// <summary>
        /// Gets or sets the ticker's open time (in Unix milliseconds).
        /// </summary>
        public long OpenTime { get; set; }

        /// <summary>
        /// Gets or sets the ticker's close time (in Unix milliseconds).
        /// </summary>
        public long CloseTime { get; set; }
    }
}
