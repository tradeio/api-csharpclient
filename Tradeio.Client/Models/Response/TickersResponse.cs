namespace Tradeio.Client.Models.Response
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents response to tickers request.
    /// </summary>
    public class TickersResponse : Response
    {
        /// <summary>
        /// Gets or sets collection of tickers.
        /// </summary>
        public ICollection<Ticker> Tickers { get; set; }
    }
}
