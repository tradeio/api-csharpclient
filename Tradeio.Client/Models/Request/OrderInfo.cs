namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents information about order.
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// Gets or sets trading pairs symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets order side.
        /// </summary>
        public OrderSide Side { get; set; }

        /// <summary>
        /// Gets or sets order type.
        /// </summary>
        public OrderType Type { get; set; }

        /// <summary>
        /// Gets or sets order identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets order price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets order's quantity.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets order's filled quantity.
        /// </summary>
        public decimal FilledQuantity { get; set; }

        /// <summary>
        /// Gets or sets commission taked on the order.
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        /// Gets or sets order's status.
        /// </summary>
        public OrderStatus Status { get; set; }
    }
}
