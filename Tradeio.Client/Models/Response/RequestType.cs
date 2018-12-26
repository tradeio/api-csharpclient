namespace Tradeio.Client.Models.Response
{
    /// <summary>
    /// Represents type of the request for rate limiting.
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// The request weight to consider.
        /// </summary>
        Weight,

        /// <summary>
        /// The order request count to consider.
        /// </summary>
        Order,
    }
}
