namespace Tradeio.Client.Models.Response
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents response to trading pairs details request.
    /// </summary>
    public class InfoResponse : Response
    {
        /// <summary>
        /// Gets or sets collection of trading pairs with details.
        /// </summary>
        public ICollection<PairInfo> Symbols { get; set; }

        // TODO: add more properties
    }
}
