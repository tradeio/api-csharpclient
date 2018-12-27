namespace Tradeio.Client.Models.Response
{
    public class Paging
    {
        /// <summary>
        /// Current page number, 1 based
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Items per page
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Total page number
        /// </summary>
        public int Total { get; set; }
    }
}
