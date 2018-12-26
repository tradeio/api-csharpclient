namespace Tradeio.Client.Models.Response
{
    /// <summary>
    /// Represents information about a single rate limit.
    /// </summary>
    public class RateLimit
    {
        /// <summary>
        /// Gets or sets rate limit type.
        /// </summary>
        public RequestType RateLimitType { get; set; }

        /// <summary>
        /// Gets or sets rate limit time period (interval).
        /// </summary>
        public TimePeriod Interval { get; set; }

        /// <summary>
        /// Gets or sets rate limit value.
        /// </summary>
        public long Limit { get; set; }
    }
}
