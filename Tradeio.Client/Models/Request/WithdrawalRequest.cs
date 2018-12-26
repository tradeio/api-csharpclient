namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents information about withdraw.
    /// </summary>
    public class WithdrawalRequest
    {
        /// <summary>
        /// Gets or sets unique identifier for transfer to perform.
        /// </summary>
        public string TransferId { get; set; }

        /// <summary>
        /// Gets or sets asset to perform withdrawal for.
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Gets or sets address to withdraw funds to.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets asset amount to withdraw.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets type of the payment system to use.
        /// </summary>
        public PaymentSystem Payment { get; set; }
    }
}
