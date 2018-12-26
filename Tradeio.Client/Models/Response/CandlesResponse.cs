namespace Tradeio.Client.Models.Response
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents response to candlestick bars request.
    /// </summary>
    public class CandlesResponse : Response
    {
        /// <summary>
        /// Gets or sets collection of candlesticks.
        /// </summary>
        public ICollection<CandleInfo> Candles { get; set; }
    }
}
