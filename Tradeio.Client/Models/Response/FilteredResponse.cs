namespace Tradeio.Client.Models.Response
{
    using System;
    using System.Linq;

    public class FilteredResponse<T> : PagedResponse<T>
    {
        public object Filters { get; set; }

        public static FilteredResponse<T> Empty<F>(F filters) where F : Paginal
        {
            return new FilteredResponse<T>
            {
                Data = new T[0],
                Paging = filters.ToPaging(0),
                Filters = filters
            };
        }

        public FilteredResponse<U> Map<U>(Func<T, U> map)
        {
            return new FilteredResponse<U>
            {
                Data = Data.Select(map).ToList(),
                Filters = Filters,
                Paging = Paging
            };
        }

    }
}
