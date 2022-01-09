using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace api.Helpers {
    public class HashCode {
        public static string Get(string password, byte[] salt, int lenght = 30) {
            byte[] byteHash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 10000, numBytesRequested: lenght);
            string stringHash = Convert.ToBase64String(byteHash);
            return $"{Convert.ToBase64String(salt)}:{stringHash}";
        }

        public static string GetRandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++) {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        public static byte[] CreateSalt(int lenght = 10) {
            RNGCryptoServiceProvider rncCsp = new RNGCryptoServiceProvider();
            byte[] salt = new byte[lenght];
            rncCsp.GetNonZeroBytes(salt);
            return salt;
        }
    }
}
