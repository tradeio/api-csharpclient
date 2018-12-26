namespace Tradeio.Client.Models.Response
{
    public interface IOrderInfo
    {

        string Type { get; set; }


        decimal RequestedAmount { get; set; }


        decimal Price { get; set; }


        bool IsLimit { get; set; }


        decimal LoanRate { get; set; }


        decimal RateStop { get; set; }


        string Instrument { get; set; }
    }
}