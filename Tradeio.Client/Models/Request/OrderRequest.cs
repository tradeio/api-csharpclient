namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents information about order to place.
    /// </summary>
    public class OrderRequest
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
        /// Gets or sets order price (used if <see cref="Type"/> is <see cref="OrderType.Limit"/> or <see cref="OrderType.StopLimit"/>).
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets order stop price (used if <see cref="Type"/> is <see cref="OrderType.StopLimit"/> or <see cref="OrderType.StopMarket"/>).
        /// </summary>
        public decimal StopPrice { get; set; }

        /// <summary>
        /// Gets or sets order's quantity.
        /// </summary>
        public decimal Quantity { get; set; }

        public override string ToString()
        {
            return $"{nameof(Symbol)}: {Symbol}, {nameof(Side)}: {Side}, {nameof(Type)}: {Type}, {nameof(Price)}: {Price}, {nameof(StopPrice)}: {StopPrice}, {nameof(Quantity)}: {Quantity}";
        }
    }
}
