using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;


namespace ShortId
{
    public class ShortId
    {
        private static readonly string ServerHash;

        static ShortId()
        {
            //get server hash
            string hostname = Dns.GetHostName();
            if (string.IsNullOrWhiteSpace(hostname))
            {
                hostname = Environment.MachineName;
            }

            string hashHex;
            using (var sha1 = new SHA1Managed())
            {
                hashHex = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(hostname)));
            }

            ServerHash = hashHex.Substring(0, 2);
        }

        public static string New()
        {
            //get hash code
            string hashCode = Guid.NewGuid().ToString().GetHashCode().ToString("x").ToUpper();

            if (hashCode.Length < 8)
            {
                hashCode = hashCode.PadLeft(8, 'Z');
            }

            string tempId = DateTime.UtcNow.ToString("yy") + hashCode + ServerHash;

            StringBuilder id = new StringBuilder();
            id.Append(tempId.Substring(0, 4));
            id.Append("-");

            id.Append(tempId.Substring(4, 4));
            id.Append("-");

            id.Append(tempId.Substring(8, 4));

            
            return id.ToString();
        }

    }
}
