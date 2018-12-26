namespace Tradeio.Client.Models.Response
{
    using Newtonsoft.Json;
    using Tradeio.Client.Utils;

    /// <summary>
    /// Represents response to request.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        public Response()
        {
            this.Error = ErrorCode.Success;
            this.Timestamp = UnixTime.GetCurrent();
        }

        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        [JsonProperty(Order = -5)]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        [JsonProperty(Order = -4)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the response timestamp (in Unix milliseconds).
        /// </summary>
        [JsonProperty(Order = -3)]
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the response code for inner use.
        /// </summary>
        [JsonIgnore]
        internal ErrorCode Error
        {
            get => (ErrorCode)this.Code;

            set => this.Code = (int)value;
        }

        /// <summary>
        /// Sets internal error response message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public void SetError(string message)
        {
            this.Error = ErrorCode.InternalError;
            this.Message = message;
        }
    }
}
