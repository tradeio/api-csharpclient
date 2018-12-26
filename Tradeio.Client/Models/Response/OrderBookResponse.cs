namespace Tradeio.Client.Models.Response
{

    /// <summary>
    /// Represents response to order book request.
    /// </summary>
    public class OrderBookResponse : Response
    {
        /// <summary>
        /// Gets or sets order book details.
        /// </summary>
        public OrderBook Book { get; set; }
    }
}
