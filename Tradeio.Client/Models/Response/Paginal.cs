using System;
using System.Collections.Generic;
using System.Text;

namespace Tradeio.Client.Models.Response
{
    public class Paginal
    {
        private const int MaxPerPage = 250;
        private const int DefaultPerPage = 15;

        /// <summary>
        /// Requested Page, 1 based
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Requested items per page count
        /// </summary>
        public int? PerPage { get; set; }


        public Paging ToPaging(int totalItems)
        {
            var perPage = Math.Min(PerPage ?? DefaultPerPage, MaxPerPage);
            return new Paging
            {
                Page = Math.Max(1, Page ?? 1),
                PerPage = perPage,
                Total = (int)Math.Ceiling(totalItems / (decimal)perPage)
            };
        }
    }
}
