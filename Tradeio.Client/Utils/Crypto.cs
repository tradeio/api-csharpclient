namespace Tradeio.Client.Utils
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Provides various cryptographic utility methods.
    /// </summary>
    public static class Crypto
    {
        /// <summary>
        /// Encodes a byte array into hexadecimal string.
        /// </summary>
        /// <param name="array">A byte-array to encode.</param>
        /// <param name="uppercase">Indicates whether the returned hexadecimal string should be in uppercase.</param>
        /// <returns>Hex-encoded string.</returns>
        public static string HexEncode(byte[] array, bool uppercase = true)
        {
            if (array == null || array.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder hex = new StringBuilder(array.Length * 2);
            foreach (byte b in array)
            {
                hex.AppendFormat(uppercase ? "{0:X2}" : "{0:x2}", b);
            }

            return hex.ToString();
        }

        /// <summary>
        /// Signs a message with SHA512 hash.
        /// </summary>
        /// <param name="message">Message to sign.</param>
        /// <param name="key">Private key bytes.</param>
        /// <param name="uppercase">Indicates whether the returned hexadecimal string should be in uppercase.</param>
        /// <returns>Signature in hex.</returns>
        public static string Sha512Sign(string message, byte[] key, bool uppercase = true)
        {
            if (message == null || key == null)
            {
                return string.Empty;
            }

            byte[] hash;
            using (var hmac = new HMACSHA512(key))
            {
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            }

            return HexEncode(hash, uppercase);
        }
    }
}
