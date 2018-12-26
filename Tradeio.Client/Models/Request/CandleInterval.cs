namespace Tradeio.Client.Models
{
    /// <summary>
    /// Represents candlestick interval.
    /// </summary>
    public enum CandleInterval
    {
        /// <summary>
        /// No interval (should not be used).
        /// </summary>
        None,

        /// <summary>
        /// One minute interval.
        /// </summary>
        OneMinute,

        /// <summary>
        /// Five minutes interval.
        /// </summary>
        FiveMinutes,

        /// <summary>
        /// Fifteen minutes interval.
        /// </summary>
        FifteenMinutes,

        /// <summary>
        /// Thirty minutes interval.
        /// </summary>
        ThirtyMinutes,

        /// <summary>
        /// One hour interval.
        /// </summary>
        OneHour,

        /// <summary>
        /// Two hours interval.
        /// </summary>
        TwoHours,

        /// <summary>
        /// Four hours interval.
        /// </summary>
        FourHours,

        /// <summary>
        /// Eight hours interval.
        /// </summary>
        EightHours,

        /// <summary>
        /// Twelve hours interval.
        /// </summary>
        TwelveHours,

        /// <summary>
        /// One day interval.
        /// </summary>
        OneDay,

        /// <summary>
        /// One week interval.
        /// </summary>
        OneWeek,

        /// <summary>
        /// One month interval.
        /// </summary>
        OneMonth,

        /// <summary>
        /// One year interval.
        /// </summary>
        OneYear,
    }
}
