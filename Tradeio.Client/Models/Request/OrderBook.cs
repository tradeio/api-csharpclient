namespace Tradeio.Client.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an order book.
    /// </summary>
    public class OrderBook
    {
        /// <summary>
        /// Gets or sets associated symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets collection of asks (price/quantity pairs).
        /// </summary>
        public ICollection<decimal[]> Asks { get; set; }

        /// <summary>
        /// Gets or sets collection of bids (price/quantity pairs).
        /// </summary>
        public ICollection<decimal[]> Bids { get; set; }
    }
}
