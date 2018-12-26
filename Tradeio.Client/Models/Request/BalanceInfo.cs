namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents information about balance on a single asset.
    /// </summary>
    public class BalanceInfo
    {
        /// <summary>
        /// Gets or sets asset name.
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Gets or sets asset's available funds.
        /// </summary>
        public decimal Available { get; set; }

        /// <summary>
        /// Gets or sets asset's locked funds.
        /// </summary>
        public decimal Locked { get; set; }
    }
}
