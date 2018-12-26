namespace Tradeio.Client.Models.Response
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents response to trading pairs request.
    /// </summary>
    public class PairsResponse : Response
    {
        /// <summary>
        /// Gets or sets collection of trading pair names.
        /// </summary>
        public ICollection<string> Pairs { get; set; }
    }
}
