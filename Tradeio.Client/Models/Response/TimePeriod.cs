namespace Tradeio.Client.Models.Response
{
    /// <summary>
    /// Represents time period the rate limit applies to.
    /// </summary>
    public enum TimePeriod
    {
        /// <summary>
        /// One minute rate limit.
        /// </summary>
        Minute,

        /// <summary>
        /// One hour rate limit.
        /// </summary>
        Hour,

        /// <summary>
        /// One day rate limit.
        /// </summary>
        Day,
    }
}
