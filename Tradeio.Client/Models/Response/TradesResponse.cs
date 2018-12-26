namespace Tradeio.Client.Models.Response
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents response to recent trades request.
    /// </summary>
    public class TradesResponse : Response
    {
        /// <summary>
        /// Gets or sets collection of recent trades.
        /// </summary>
        public ICollection<TradeInfo> Trades { get; set; }
    }
}
