namespace Tradeio.Client.Models.Response
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents response to account balance request.
    /// </summary>
    public class AccountBalanceResponse : Response
    {
        /// <summary>
        /// Gets or sets collection of balances.
        /// </summary>
        public ICollection<BalanceInfo> Balances { get; set; }
    }
}
