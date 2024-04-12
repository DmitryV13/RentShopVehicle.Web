using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Helpers
{
    public static class CookieGenerator
    {
        private const string SaltData1 = "aPo0JfB7Cgiw0VMB";
        private const string SaltData2 = "QJ2YdPVRLKCp2jZt";
        private static readonly byte[] salt = Encoding.ASCII.GetBytes(SaltData1 + SaltData2);

        public static string Create(string key)
        {
            return EncryptStringAES(key, salt, Encoding.ASCII.GetBytes(SaltData2));
        }

        public static string Validate(string value)
        {
            return DecryptStringAES(value, salt, Encoding.ASCII.GetBytes(SaltData2));
        }

        public static string EncryptStringAES(string plainText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        public static string DecryptStringAES(string encryptedText, byte[] key, byte[] iv)
        {
            byte[] cipherText = Convert.FromBase64String(encryptedText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
