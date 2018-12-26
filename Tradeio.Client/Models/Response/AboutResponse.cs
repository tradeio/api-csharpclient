namespace Tradeio.Client.Models.Response
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents response to `about` request.
    /// </summary>
    public class AboutResponse : TimeResponse
    {
        /// <summary>
        /// Gets or sets exchange name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets exchange description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets collection of rate limits.
        /// </summary>
        public ICollection<RateLimit> RateLimits { get; set; }
    }
}
