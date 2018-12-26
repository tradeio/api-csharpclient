namespace Tradeio.Client.Models.Response
{
    /// <summary>
    /// Represents response to withdrawal request.
    /// </summary>
    public class WithdrawalResponse : Response
    {
        /// <summary>
        /// Gets or sets associated transaction identifier.
        /// </summary>
        public string TransactionId { get; set; }
    }
}
