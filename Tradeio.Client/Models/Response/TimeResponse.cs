namespace Tradeio.Client.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents response to server time request.
    /// </summary>
    public class TimeResponse : Response
    {
        /// <summary>
        /// Gets or sets server's timezone.
        /// </summary>
        [JsonProperty(Order = -2)]
        public string Timezone { get; set; } = "UTC";
    }
}
