using System;
using System.Security.Cryptography;
using System.Text;

namespace ScannerApp.ClassFiles
{
    public class SHAEncryption
    {
        public string HashKey { get; set; }

        private TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();

        private byte[] TruncateHash(string key, int length)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            // Hash the key.
            var keyBytes = Encoding.Unicode.GetBytes(key);
            var hash = sha1.ComputeHash(keyBytes);

            // Truncate or pad the hash.
            Array.Resize(ref hash, length);
            return hash;
        }

        public string EncryptData(string plaintext)
        {

            // Initialize the crypto provider.
            TripleDes.Key = TruncateHash(HashKey, TripleDes.KeySize / 8);
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8);

            // Convert the plaintext string to a byte array.
            var plaintextBytes = Encoding.Unicode.GetBytes(plaintext);

            // Create the stream.
            var ms = new System.IO.MemoryStream();
            // Create the encoder to write to the stream.
            var encStream = new CryptoStream(ms, TripleDes.CreateEncryptor(), CryptoStreamMode.Write);

            // Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length);
            encStream.FlushFinalBlock();

            // Convert the encrypted stream to a printable string.
            return Convert.ToBase64String(ms.ToArray());
        }

        public string DecryptData(string encryptedtext)
        {

            // Initialize the crypto provider.
            TripleDes.Key = TruncateHash(HashKey, TripleDes.KeySize / 8);
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8);

            // Convert the encrypted text string to a byte array.
            var encryptedBytes = Convert.FromBase64String(encryptedtext);

            // Create the stream.
            var ms = new System.IO.MemoryStream();
            // Create the decoder to write to the stream.
            var decStream = new CryptoStream(ms, TripleDes.CreateDecryptor(), CryptoStreamMode.Write);

            // Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            decStream.FlushFinalBlock();

            // Convert the plaintext stream to a string.
            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}