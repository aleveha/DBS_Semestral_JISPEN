using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace api.Helpers.HashUtility {
    public class HashUtility {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GetHash(string value, int lenght = 30) {
            byte[] salt = CreateSalt();
            string stringHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(value, salt, KeyDerivationPrf.HMACSHA256, 10000, lenght));
            return $"{Convert.ToBase64String(salt)}:{stringHash}";
        }

        public static string GetHash(string value, byte[] salt, int lenght = 30) {
            string stringHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(value, salt, KeyDerivationPrf.HMACSHA256, 10000, lenght));
            return $"{Convert.ToBase64String(salt)}:{stringHash}";
        }

        public static string GetRandomString(int length) {
            char[] stringChars = new char[length];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++) {
                stringChars[i] = Chars[random.Next(Chars.Length)];
            }

            return new string(stringChars);
        }

        private static byte[] CreateSalt(int lenght = 10) {
            byte[] salt = new byte[lenght];
            new RNGCryptoServiceProvider().GetNonZeroBytes(salt);
            return salt;
        }
    }
}
