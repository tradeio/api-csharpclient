namespace Tradeio.Client
{

    using System.Text;
    public static class ByteArrayExtensions
    {
        private static readonly char[] Hex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        public static string ToHex(this byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(Hex[bytes[i] >> 4]);
                sb.Append(Hex[bytes[i] & 0xF]);
            }
            return sb.ToString();
        }
    }
}