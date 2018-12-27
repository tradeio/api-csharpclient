using System;
using System.Collections.Generic;
using System.Text;

namespace Tradeio.Client.Models.Response
{
    public class PagedResponse<T> : Response<IList<T>>
    {
        internal PagedResponse() { }

        public Paging Paging { get; set; }
    }
}
