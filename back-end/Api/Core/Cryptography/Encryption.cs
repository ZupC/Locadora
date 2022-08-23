using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Api.Core.Cryptography
{
    public class Encryption
    {
        static readonly char[] padding = { '=' };

        public static string Encrypt(string clearText)
        {
           return Base64UrlEncoder.Encode(clearText);
        }

        public static string Decrypt(string cipherText)
        {
            return Base64UrlEncoder.Decode(cipherText);
        }

        public static int DecryptToInt(string cipherText)
        {
            return Convert.ToInt32(Decrypt(cipherText));
        }
    }
}
