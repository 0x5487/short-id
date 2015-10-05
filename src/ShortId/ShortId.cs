using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;


namespace JasonSoft
{
    //reference: http://weblog.west-wind.com/posts/2006/Mar/09/Creating-a-unique-or-semiunique-ID-in-NET

    public class ShortId
    {
        private static readonly string ServerHash;

        static ShortId()
        {
            //get machine hash
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
            int maxSize = 8;
            char[] chars = new char[62];
            string all = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"; 
            chars = all.ToCharArray();

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            var data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                int pick = b % (chars.Length - 1);
                result.Append(chars[pick]);
            }
            var hashCode = result.ToString();

            //string id = DateTime.UtcNow.ToString("yy") + hashCode + ServerHash;
            //string id = hashCode + ServerHash;

            return hashCode;
        }



    }
}
