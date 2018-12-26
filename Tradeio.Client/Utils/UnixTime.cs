namespace Tradeio.Client.Utils
{
    using System;

    /// <summary>
    /// Provides Unix timestamp functionality.
    /// </summary>
    public static class UnixTime
    {
        /// <summary>
        /// Minimum Unix time.
        /// </summary>
        private static readonly DateTime UnixMinTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Returns Unix timestamp (in milliseconds) for the current time.
        /// </summary>
        /// <returns>Unix timestamp in milliseconds.</returns>
        public static long GetCurrent()
        {
            return Get(DateTime.UtcNow);
        }

        /// <summary>
        /// Returns Unix timestamp (in milliseconds) for the provided date/time.
        /// </summary>
        /// <param name="time">The date/time to get Unix timestamp for.</param>
        /// <returns>Unix timestamp in milliseconds.</returns>
        public static long Get(DateTime time)
        {
            return (long)(time - UnixMinTime).TotalMilliseconds;
        }

        /// <summary>
        /// Returns date/time for Unix timestamp (milliseconds).
        /// </summary>
        /// <param name="timestamp">Unix timestamp.</param>
        /// <returns>Date/time corresponding to the Unix timestamp.</returns>
        public static DateTime GetDateTime(long timestamp)
        {
            return UnixMinTime.AddMilliseconds(timestamp);
        }

        /// <summary>
        /// Returns date/time for Unix timestamp (milliseconds).
        /// </summary>
        /// <param name="timestamp">Unix timestamp.</param>
        /// <returns>Date/time corresponding to the Unix timestamp.</returns>
        public static DateTime? GetNullableDateTime(long timestamp)
        {
            return timestamp > 0 ? (DateTime?)GetDateTime(timestamp) : null;
        }
    }
}
