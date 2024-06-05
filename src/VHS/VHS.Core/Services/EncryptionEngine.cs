using System;
using System.Security.Cryptography;
using System.Text;

public class EncryptionEngine
{
    public string CreateKey()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            var key = new byte[32];
            rng.GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }

    public bool VerifyPassword(string password, string storedHash, string storedSalt)
    {
        var saltBytes = Convert.FromBase64String(storedSalt);
        var rfc2898 = new Rfc2898DeriveBytes(password, saltBytes, 10000);
        var hashBytes = rfc2898.GetBytes(32);

        return Convert.ToBase64String(hashBytes) == storedHash;
    }

    public (string Hash, string Salt) HashPassword(string password)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var rfc2898 = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashBytes = rfc2898.GetBytes(32);

            return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
        }
    }

    public string EncryptData(string plainText, string key)
    {
        using (var aes = Aes.Create())
        {
            var keyBytes = Convert.FromBase64String(key);
            aes.Key = keyBytes;
            aes.GenerateIV();
            var iv = aes.IV;

            using (var encryptor = aes.CreateEncryptor(aes.Key, iv))
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                var result = new byte[iv.Length + encryptedBytes.Length];
                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                Buffer.BlockCopy(encryptedBytes, 0, result, iv.Length, encryptedBytes.Length);
                return Convert.ToBase64String(result);
            }
        }
    }

    public string DecryptData(string cipherText, string key)
    {
        var fullCipher = Convert.FromBase64String(cipherText);

        using (var aes = Aes.Create())
        {
            var iv = new byte[16];
            var cipherBytes = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipherBytes, 0, cipherBytes.Length);

            aes.Key = Convert.FromBase64String(key);
            aes.IV = iv;

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                var plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                return Encoding.UTF8.GetString(plainBytes);
            }
        }
    }
}