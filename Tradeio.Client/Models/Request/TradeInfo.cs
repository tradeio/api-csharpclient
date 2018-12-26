namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents a recent trade.
    /// </summary>
    public class TradeInfo
    {
        /// <summary>
        /// Gets or sets associated symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the time (in Unix milliseconds) the trade has been performed.
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Gets or sets recent trade's unique identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the price of the performed trade.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the performed trade.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the type (sell or buy) of the performed trade.
        /// </summary>
        public string Type { get; set; }
    }
}
