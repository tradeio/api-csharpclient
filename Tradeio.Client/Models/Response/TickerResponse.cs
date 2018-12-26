namespace Tradeio.Client.Models.Response
{

    /// <summary>
    /// Represents response to ticker request.
    /// </summary>
    public class TickerResponse : Response
    {
        /// <summary>
        /// Gets or sets ticker details.
        /// </summary>
        public Ticker Ticker { get; set; }
    }
}
