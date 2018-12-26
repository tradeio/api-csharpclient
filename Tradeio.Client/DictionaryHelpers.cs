using System.Collections.Generic;
using System.Linq;

namespace Tradeio.Client
{
    public static class DictionaryHelpers
    {
        public static string Dump<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key + "=" + kv.Value).ToArray()) + "}";
        }
    }
}