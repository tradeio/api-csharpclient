namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents API keys.
    /// </summary>
    public class ApiKeys
    {
        /// <summary>
        /// Gets or sets name associated with API keys.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets public API key.
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Gets or sets private API key.
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// Gets user identifier associated with the API key.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the API key can be used to get trading information.
        /// </summary>
        public bool CanGetInfo { get; set; }

        /// <summary>
        /// Gets a value indicating whether the API key can be used to perform trading operations.
        /// </summary>
        public bool CanTrade { get; set; }

        /// <summary>
        /// Gets a value indicating whether the API key can be used to perform withdraw operations.
        /// </summary>
        public bool CanWithdraw { get; set; }

        /// <summary>
        /// Gets a comma separated value of IP white list
        /// </summary>
        public string IpAddresses { get; set; }
    }
}
