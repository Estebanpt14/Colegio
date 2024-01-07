namespace Colegio.Utilities;

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Encryptor
{
    private static byte[] SecretKey = Encoding.UTF8.GetBytes("Mqw1232ajskdahskdja223".PadRight(32));
    private static readonly int KeySize = 256;
    private static readonly int BlockSize = 128;
    
    public static string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.KeySize = KeySize;
            aesAlg.BlockSize = BlockSize;
            aesAlg.Key = SecretKey;
            aesAlg.IV = new byte[BlockSize / 8];

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

    public static string Decrypt(string cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.KeySize = KeySize;
            aesAlg.BlockSize = BlockSize;
            aesAlg.Key = SecretKey;
            aesAlg.IV = new byte[BlockSize / 8];

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
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
