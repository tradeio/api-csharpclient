namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents status of an order.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Order is accepted and pending execution. It might have been partially executed already.
        /// </summary>
        Working,

        /// <summary>
        /// Order was not accepted and has never been working on the exchange.
        /// </summary>
        Rejected,

        /// <summary>
        /// Order was cancelled by a user (either client or administrative personnel).
        /// Order might have been partially filled.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Order was completely or partially filled and removed from exchange
        /// </summary>
        Completed,
    }
}
