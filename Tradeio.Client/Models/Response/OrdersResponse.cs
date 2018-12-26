
namespace Tradeio.Client.Models.Response
{
    using System.Collections.Generic;


    /// <summary>
    /// Represents response to orders requests.
    /// </summary>
    public class OrdersResponse : Response
    {
        /// <summary>
        /// Gets or sets collection of orders.
        /// </summary>
        public ICollection<OrderInfoResponse> Orders { get; set; }
    }
}
