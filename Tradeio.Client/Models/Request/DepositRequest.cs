namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents information about deposit.
    /// </summary>
    public class DepositRequest
    {
        /// <summary>
        /// Gets or sets asset to perform deposit for.
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Gets or sets asset amount to deposit.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets type of the payment system to use.
        /// </summary>
        public PaymentSystem Payment { get; set; }
    }
}
