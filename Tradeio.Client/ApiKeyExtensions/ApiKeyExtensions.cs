namespace Tradeio.Client
{
    using System;
    using System.Security.Cryptography;

    public static class ApiKeyExtensions
    {
        public static string ComputeHash(ArraySegment<byte> data, byte[] keyBytes)
        {
            using (var hmac = new HMACSHA512(keyBytes))
            {
                return hmac.ComputeHash(data.Array, data.Offset, data.Count).ToHex();
            }
        }
    }
}
