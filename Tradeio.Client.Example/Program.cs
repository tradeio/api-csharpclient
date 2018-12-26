using System;
using Tradeio.Client.Models;
using Tradeio.Client.Models.Response;
using Tradeio.Client.Utils;

namespace Tradeio.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TradeioApi api = new TradeioApi("aaaaaaaa-bbbb-cccc-dddd-eeeeeeee", "aaaaaaaa-bbbb-cccc-dddd-eeeeeeee");
            string symbol = "btc_usdt";
            Console.WriteLine("******PAIRS******");
            PairsResponse pairsResponse = api.GetPairs().Result;
            Console.WriteLine(string.Join(',', pairsResponse.Pairs));

            Console.WriteLine("******CANDLES******");
            CandlesResponse candles = api.GetCandles("btc_usdt", CandleInterval.OneDay, DateTime.UtcNow.AddMonths(-1), DateTime.UtcNow, 20).Result;
            foreach (CandleInfo candle in candles.Candles)
            {
                Console.WriteLine($"open: {candle.Open}; close: {candle.Close}; low: {candle.Low}; high: {candle.High}");
            }

            Console.WriteLine("******ORDER BOOK******");
            OrderBookResponse orderBookResponse = api.GetOrderBook(symbol, 2).Result;
            Console.WriteLine("***ASK***");
            foreach (var askArray in orderBookResponse.Book.Asks)
            {
                Console.WriteLine($"Price: {askArray[0]}; Count: {askArray[1]}");
            }
            Console.WriteLine("***BID***");
            foreach (var bidArray in orderBookResponse.Book.Bids)
            {
                Console.WriteLine($"Price: {bidArray[0]}; Count: {bidArray[1]}");
            }

            Console.WriteLine("******TICKER******");
            TickerResponse tickerResponse = api.GetTicker(symbol).Result;
            Console.WriteLine($"ASK price: {tickerResponse.Ticker.AskPrice}, qty: {tickerResponse.Ticker.AskQty}; BID price: {tickerResponse.Ticker.BidPrice}, qty: {tickerResponse.Ticker.BidQty}");
            //tickers for all pairs
            //var tickers = api.GetTickers().Result;

            Console.WriteLine("******RECENT TRADES******");
            TradesResponse tradesResponse = api.GetRecentTrades("btc_usdt", 2).Result;
            foreach (TradeInfo trade in tradesResponse.Trades)
            {
                Console.WriteLine($"{trade.Symbol} price: {trade.Price}, qty: {trade.Quantity}, side: {trade.Type}, date: {UnixTime.GetDateTime(trade.Time)} UTC");
            }


            //PRIVATE METHODS. NOT WORKING WITHOUT PUBLIC AND PRIVATE KEY

            Console.WriteLine("******CURRENT BALANCES******");
            AccountBalanceResponse accountBalance = api.GetAccount().Result;
            foreach (BalanceInfo balanceInfo in accountBalance.Balances)
            {
                Console.WriteLine($"{balanceInfo.Asset}:{balanceInfo.Available} (locked: {balanceInfo.Locked})");
            }

            Console.WriteLine("******OPEN ORDERS******");
            OrdersResponse ordersResponse = api.GetOpenOrders(symbol).Result;
            foreach (OrderInfoResponse order in ordersResponse.Orders)
            {
                Console.WriteLine($"{order.Side} {order.Instrument} for {order.Price}. Filled: {order.UnitsFilled}");
            }
            Console.WriteLine("******CLOSED ORDERS******");
            OrdersResponse closeOrdersResponse = api.GetClosedOrders(symbol, UnixTime.Get(DateTime.UtcNow.AddDays(-1)), UnixTime.Get(DateTime.UtcNow)).Result;
            foreach (OrderInfoResponse order in closeOrdersResponse.Orders)
            {
                Console.WriteLine($"{order.Side} {order.Instrument} for {order.Price}. Filled: {order.UnitsFilled}. Status: {order.Status}");
            }
            Console.WriteLine("******PLACE ORDER******");
            var orderResponse = api.PlaceOrder(new Models.OrderRequest()
            {
                Price = 4000,
                Quantity = 10,
                Side = Models.OrderSide.Buy,
                Symbol = symbol,
                Type = Models.OrderType.Limit
            }).Result;
            Console.WriteLine("******CANCEL ORDER******");
            Response response = api.CancelOrder(orderResponse.Order.OrderId).Result;
            if (response.Code == 200)
            {
                Console.WriteLine("Order canceled");
            }
            Console.ReadLine();
        }
    }
}
