namespace Tradeio.Client.Models.Response
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    public class OrderInfoResponse : IOrderInfo
    {

        public string OrderId { get; set; }

        public decimal Total { get; set; }

        public OrderType OrderType { get; set; }

        public decimal Commission { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal UnitsFilled { get; set; }

        public bool IsPending { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus Status { get; set; }

        public string Type { get; set; }

        public decimal RequestedAmount { get; set; }

        public decimal BaseAmount { get; set; }

        public decimal QuoteAmount { get; set; }

        public decimal Price { get; set; }

        public bool IsLimit { get; set; }

        public decimal LoanRate { get; set; }

        public decimal RateStop { get; set; }

        public string Instrument { get; set; }

        public OrderSide Side
        {
            get => Type == "buy" ? OrderSide.Buy : OrderSide.Sell;
            set => Type = value == OrderSide.Buy ? "buy" : "sell";
        }

        public decimal RequestedPrice { get; set; }

        public decimal RemainingAmount { get; set; }
    }
}