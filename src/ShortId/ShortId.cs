using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;


namespace JasonSoft
{
    public class ShortId
    {
        private static readonly string ServerHash;

        static ShortId()
        {
            //get server hash
            string hostname = Dns.GetHostName();

            string hashHex;
            using (var sha1 = SHA1.Create())
            {
                hashHex = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(hostname)));
            }

            ServerHash = hashHex.Substring(0, 2);
        }

        public static string New()
        {
            //get hash code
            string hashCode = Guid.NewGuid().GetHashCode().ToString("x");

            if (hashCode.Length < 8)
            {
                hashCode = hashCode.PadLeft(8, 'Z');
            }

            string id = DateTime.UtcNow.ToString("yy") + hashCode + ServerHash;

            return id.ToUpper();
        }

    }
}
