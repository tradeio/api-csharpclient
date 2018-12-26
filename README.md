# Tradeio client (C#)

* Official documentations: **https://gitlab.com/trade-io/official-api-docs**

### Create connector
TradeioApi api = new TradeioApi("public_key", "private_key");

## Public methods (available without auth)
### Pairs
PairsResponse pairsResponse = api.GetPairs().Result;
### Candels
CandlesResponse candles = api.GetCandles("btc_usdt", CandleInterval.OneDay, DateTime.UtcNow.AddMonths(-1), DateTime.UtcNow, 20).Result;
### Order book
OrderBookResponse orderBookResponse = api.GetOrderBook("btc_usdt", 20).Result;
### Ticker
TickerResponse tickerResponse = api.GetTicker("btc_usdt").Result;
### Recent trades
TradesResponse tradesResponse = api.GetRecentTrades("btc_usdt", 20).Result;

## Pravate methods. (not working without auth, needs public and pravete key
### Current balances
AccountBalanceResponse accountBalance = api.GetAccount().Result;
### Open orders
OrdersResponse ordersResponse = api.GetOpenOrders("btc_usdt").Result;
### Closed orders
OrdersResponse closeOrdersResponse = api.GetClosedOrders("btc_usdt", UnixTime.Get(DateTime.UtcNow.AddDays(-1)), UnixTime.Get(DateTime.UtcNow)).Result;
### Place order
var orderResponse = api.PlaceOrder(new Models.OrderRequest()
{
    Price = 4000,
    Quantity = 10,
    Side = Models.OrderSide.Buy,
    Symbol = symbol,
    Type = Models.OrderType.Limit
}).Result;
### Cancel order
Response response = api.CancelOrder(orderResponse.Order.OrderId).Result;
