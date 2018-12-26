namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents error codes.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Success (no error).
        /// </summary>
        Success = 0,

        /// <summary>
        /// Provided symbol is invalid.
        /// </summary>
        InvalidSymbol = 1,

        /// <summary>
        /// Provided Candlestick interval is invalid.
        /// </summary>
        InvalidInterval = 2,

        /// <summary>
        /// Generic internal error.
        /// </summary>
        InternalError = 500,
    }
}
