using System;
using System.Security.Cryptography;
using System.Text;



namespace ShopMetta
{
    public class Hasher
    {
        public static string HashString(string input)
        {
            using (var hmac = new HMACSHA256())
            {
                byte[] salt = hmac.Key;
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

                return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
            }
        }

        public static bool VerifyHash(string hashedInput, string providedInput)
        {
            var parts = hashedInput.Split('.');
            if (parts.Length != 2)
            {
                throw new FormatException("Unexpected hash format.");
            }

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] hash = Convert.FromBase64String(parts[1]);

            using (var hmac = new HMACSHA256(salt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(providedInput));
                return CompareHashes(hash, computedHash);
            }
        }

        private static bool CompareHashes(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length) return false;

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i]) return false;
            }

            return true;
        }
    }
}
