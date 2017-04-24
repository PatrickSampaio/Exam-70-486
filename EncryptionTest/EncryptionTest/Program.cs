using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string original = "My secret data!";

            using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                string roundtrip = Decrypt(symmetricAlgorithm, encrypted);
                Console.WriteLine(encrypted);
                Console.WriteLine(roundtrip);
            }
        }

        public static byte[] Encrypt(SymmetricAlgorithm algorithm, string originalText)
        {
            ICryptoTransform encryptator = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);

            using (MemoryStream memoEncrypt = new MemoryStream())
            {
                using (CryptoStream cryptEncrypt = new CryptoStream(memoEncrypt, encryptator, CryptoStreamMode.Write))
                {
                    using (StreamWriter writerEncrypt = new StreamWriter(cryptEncrypt))
                    {
                        writerEncrypt.Write(originalText);
                    }
                    return memoEncrypt.ToArray();
                }
            }
        }

        public static string Decrypt(SymmetricAlgorithm algorithm, byte[] encrypted)
        {
            ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);

            using (MemoryStream memoDecrypt = new MemoryStream(encrypted))
            {
                using (CryptoStream cryptoDecrypt = new CryptoStream(memoDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader readerDecrypt = new StreamReader(cryptoDecrypt))
                    {
                        return readerDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
