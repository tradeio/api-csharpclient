namespace Tradeio.Client.Models.Response
{
    /// <summary>
    /// Represents response to order requests.
    /// </summary>
    public class OrderResponse : Response
    {
        /// <summary>
        /// Gets or sets information about order.
        /// </summary>
        public OrderInfoResponse Order { get; set; }
    }
}
