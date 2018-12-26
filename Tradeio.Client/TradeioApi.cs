namespace Tradeio.Client
{
    using System.Globalization;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Tradeio.Client.Models;
    using Tradeio.Client.Utils;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Tradeio.Client.Models.Response;

    /// <summary>
    /// Provides Trade.io API functionality.
    /// </summary>
    public class TradeioApi : IDisposable
    {
        /// <summary>
        /// Gets base URL for the API.
        /// </summary>
        private readonly string baseUrl = "https://api.dev1env.trade.io/api/v1";

        /// <summary>
        /// HTTP client instance.
        /// </summary>
        private readonly RequestHttpMaker client = new RequestHttpMaker();

        /// <summary>
        /// Exchange's public key.
        /// </summary>
        private readonly string publicKey;

        /// <summary>
        /// Exchange's private key.
        /// </summary>
        private readonly byte[] privateKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="TradeioApi"/> instance.
        /// </summary>
        /// <param name="baseUrl">Base URL to the service.</param>
        public TradeioApi(string baseUrl = null)
        {
            if (!string.IsNullOrEmpty(baseUrl))
            {
                this.baseUrl = baseUrl;
            }

            this.publicKey = string.Empty;
            this.privateKey = new byte[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TradeioApi"/> instance.
        /// </summary>
        /// <param name="publicKey">Exchange's public key.</param>
        /// <param name="privateKey">Exchange's private key.</param>
        /// <param name="baseUrl">Base URL to the service.</param>
        public TradeioApi(string publicKey, string privateKey, string baseUrl = null)
        {
            if (!string.IsNullOrEmpty(baseUrl))
            {
                this.baseUrl = baseUrl;
            }

            this.publicKey = publicKey ?? string.Empty;
            this.privateKey = Encoding.UTF8.GetBytes(privateKey ?? string.Empty);
        }

        #region public methods
        public async Task<PairsResponse> GetPairs()
        {
            return await this.Send<PairsResponse>("/pairs");
        }

        public async Task<InfoResponse> GetInfo()
        {
            return await this.Send<InfoResponse>("/info");
        }

        public async Task<CandlesResponse> GetCandles(string symbol, CandleInterval interval, DateTime start, DateTime end, int limit)
        {
            IDictionary<string, object> form = new Dictionary<string, object>(3)
            {
                ["start"] = UnixTime.Get(start),
                ["end"] = UnixTime.Get(end),
                ["limit"] = limit
            };
            return await this.Send<CandlesResponse>($"/klines/{symbol}/{this.ConvertToString(interval)}");
        }

        public async Task<OrderBookResponse> GetOrderBook(string symbol, int limit = 100)
        {
            IDictionary<string, object> form = new Dictionary<string, object>()
            {
                ["limit"] = limit
            };
            return await this.Send<OrderBookResponse>($"/depth/{symbol}", form);
        }

        public async Task<TickerResponse> GetTicker(string symbol)
        {
            return await this.Send<TickerResponse>($"/ticker/{symbol}");
        }

        public async Task<TickersResponse> GetTickers()
        {
            return await this.Send<TickersResponse>($"/tickers");
        }

        public async Task<TradesResponse> GetRecentTrades(string symbol, int limit)
        {
            IDictionary<string, object> form = new Dictionary<string, object>()
            {
                ["limit"] = limit
            };
            return await this.Send<TradesResponse>($"/trades/{symbol}", form);
        }

        #endregion

        /// <summary>
        /// Places a new order.
        /// </summary>
        /// <param name="request">Order request.</param>
        /// <returns>Order response string.</returns>
        public async Task<OrderResponse> PlaceOrder(OrderRequest request)
        {
            IDictionary<string, object> form = new Dictionary<string, object>(6);
            form["Symbol"] = request.Symbol.ToString().ToLowerInvariant();
            form["Side"] = request.Side.ToString().ToLowerInvariant();
            form["Type"] = request.Type.ToString().ToLowerInvariant();
            form["Quantity"] = request.Quantity;
            if (request.Type == OrderType.Limit || request.Type == OrderType.StopLimit)
            {
                form["Price"] = request.Price;
            }

            if (request.Type == OrderType.StopLimit || request.Type == OrderType.StopMarket)
            {
                form["StopPrice"] = request.StopPrice;
            }

            return await this.SignAndSend<OrderResponse>($"/order", form, "POST");
        }

        public async Task<Response> CancelOrder(string orderId)
        {
            return await this.SignAndSend<Response>($"/order/{orderId}", null, "DELETE");
        }

        public async Task<OrdersResponse> GetOpenOrders(string symbol)
        {
            return await this.SignAndSend<OrdersResponse>($"/openOrders/{symbol}", null, "GET");
        }

        public async Task<OrdersResponse> GetClosedOrders(string symbol, long start, long end, int limit = 100)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>(4);
            payload["start"] = start;
            payload["end"] = end;
            payload["limit"] = limit;
            return await this.SignAndSend<OrdersResponse>($"/closedOrders/{symbol}", payload, "GET");
        }

        public async Task<AccountBalanceResponse> GetAccount()
        {
            return await this.SignAndSend<AccountBalanceResponse>("/account", null, "GET");
        }

        public async Task<JToken> GetTestApiKeys()
        {
            return await this.SignAndSend<JToken>("/testApiKeys", null, "GET");
        }


        /// <summary>
        /// Disposes any resource being used.
        /// </summary>
        public void Dispose()
        {
            this.client?.Dispose();
        }

        /// <summary>
        /// Returns a form for a request (form-encoded, like a query string).
        /// </summary>
        /// <param name="payload">Payload to process.</param>
        /// <returns>Form string</returns>
        private static string GetFormForPayload(IDictionary<string, object> payload)
        {
            if (payload == null || payload.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder form = new StringBuilder();
            foreach (KeyValuePair<string, object> keyValue in payload)
            {
                if (keyValue.Key != null && keyValue.Value != null)
                {
                    form.AppendFormat("{0}={1}&", Uri.EscapeDataString(keyValue.Key), Uri.EscapeDataString(keyValue.Value.ToString()));
                }
            }

            if (form.Length != 0)
            {
                form.Length--; // trim last ampersand
            }

            return form.ToString();
        }

        public async Task<T> SignAndSend<T>(string url, IDictionary<string, object> payload, string method, string publicKey = null, string privateKey = null)
        {
            IDictionary<string, string> headers = new Dictionary<string, string>(2);

            if (payload == null)
            {
                payload = new Dictionary<string, object>(1);
            }
  
            payload["ts"] = UnixTime.GetCurrent().ToString(CultureInfo.InvariantCulture);

            string form = null;
            string formForPayload = GetFormForPayload(payload);
            string sign;
            string mediaType = null;
            if (method != "POST")
            {
                var reqstr = '?' + formForPayload;
                url += reqstr;
                sign = CalcSign(reqstr, (privateKey == null ? this.privateKey : Encoding.UTF8.GetBytes(privateKey)));
            }
            else
            {
                form = JsonConvert.SerializeObject(payload);
                mediaType = "application/json";
                sign = CalcSign(form, (privateKey == null ? this.privateKey : Encoding.UTF8.GetBytes(privateKey)));
            }


            headers["Key"] = publicKey ?? this.publicKey;
            headers["Sign"] = sign;
            headers["ts"] = UnixTime.GetCurrent().ToString();


            string response = await this.client.MakeRequestAsync(this.baseUrl + url, method: method, headers: headers, form: form, mediaType: mediaType);
            return JsonConvert.DeserializeObject<T>(response);
        }

        private async Task<T> Send<T>(string url, IDictionary<string, object> payload = null)
        {
            string form = string.Empty;
            if (payload != null && payload.Count != 0)
            {
                string formForPayload = GetFormForPayload(payload);
                var reqstr = '?' + formForPayload;
                url += reqstr;
            }


            string response = await this.client.MakeRequestAsync(this.baseUrl + url, form: form);
            return JsonConvert.DeserializeObject<T>(response);
        }

        private string CalcSign(string form, byte[] privateKey)
        {
            var data = new ArraySegment<byte>(Encoding.UTF8.GetBytes(form));
            var keyBytes = privateKey;
            return ApiKeyExtensions.ComputeHash(data, keyBytes);
        }

        public string ConvertToString(CandleInterval candleInterval)
        {
            switch (candleInterval)
            {
                case CandleInterval.None:
                    return string.Empty;
                case CandleInterval.OneMinute:
                    return "1m";
                case CandleInterval.FiveMinutes:
                    return "5m";
                case CandleInterval.FifteenMinutes:
                    return "15m";
                case CandleInterval.ThirtyMinutes:
                    return "30m";
                case CandleInterval.OneHour:
                    return "1h";
                case CandleInterval.TwoHours:
                    return "2h";
                case CandleInterval.FourHours:
                    return "4h";
                case CandleInterval.EightHours:
                    return "8h";
                case CandleInterval.TwelveHours:
                    return "12h";
                case CandleInterval.OneDay:
                    return "1d";
                case CandleInterval.OneWeek:
                    return "1w";
                case CandleInterval.OneMonth:
                    return "1m";
                case CandleInterval.OneYear:
                    return "1y";
                default:
                    return string.Empty;
            }
        }

        
    }
}
