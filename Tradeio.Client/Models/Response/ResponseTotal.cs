namespace Tradeio.Client.Models.Response
{
    public class Response<T>
    {
        internal Response() { }

        public T Data { get; set; }
    }
}
