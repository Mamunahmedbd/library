using System;
using System.Security.Cryptography;

namespace Library
{
    public static class SecurityHelper
    {
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 32; // 256 bit
        private const int Iterations = 10000;

        public static string CreateHash(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                // Format: {iterations}.{saltBase64}.{hashBase64}
                return string.Format("{0}.{1}.{2}", Iterations, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(storedHash)) return false;

            var parts = storedHash.Split('.');
            if (parts.Length != 3) return false;

            int iterations;
            if (!int.TryParse(parts[0], out iterations)) return false;

            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] hash = Convert.FromBase64String(parts[2]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] testHash = pbkdf2.GetBytes(hash.Length);
                return AreEqual(hash, testHash);
            }
        }

        private static bool AreEqual(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}
