using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShortId
{
    public static class ShortId
    {
        public static string New()
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
                hashHex = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(hostname)));
            }

            var data = Convert.FromBase64String(hashHex);
            string serverHash = BitConverter.ToString(data).Replace("-", string.Empty);
            if (serverHash.Length > 2)
                serverHash = serverHash.Substring(0, 2);

            //get hash code
            string hashCode = Guid.NewGuid().ToString().GetHashCode().ToString("x");

            if (hashCode.Length < 8)
            {
                hashCode = hashCode.PadLeft(8, 'z');
            }

            string tempId = DateTime.UtcNow.ToString("yy") + hashCode + serverHash;

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
