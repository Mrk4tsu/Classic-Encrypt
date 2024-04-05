using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace MaDES.Encrypt
{
    public class RijndaelEncrypt : IEncryptor
    {
        public static RijndaelEncrypt instance { get; } = new RijndaelEncrypt();

        public string GenerateKey()
        {
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.GenerateKey();

                string key = BitConverter.ToString(rijndael.Key).Replace("-", "");
                return key.ToLower();
            }
        }
        public string GenerateIV()
        {
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.GenerateIV();

                string iv = BitConverter.ToString(rijndael.IV).Replace("-", "");
                return iv.ToLower();
            }
        }
        public void EncryptFile(string filePath, string encryptedFilePath, string key, string iv)
        {
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.Key = StringToByteArray(key);
                rijndael.IV = StringToByteArray(iv);

                ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                using (FileStream originalFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (CryptoStream cryptoStream = new CryptoStream(originalFileStream, encryptor, CryptoStreamMode.Read))
                {
                    using (FileStream encryptedFileStream = new FileStream(encryptedFilePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            encryptedFileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
        public void DecryptFile(string encryptedFilePath, string decryptedFilePath, string key, string iv)
        {
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.Key = StringToByteArray(key);
                rijndael.IV = StringToByteArray(iv);

                ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                using (FileStream encryptedFileStream = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read))
                using (CryptoStream cryptoStream = new CryptoStream(encryptedFileStream, decryptor, CryptoStreamMode.Read))
                {
                    using (FileStream decryptedFileStream = new FileStream(decryptedFilePath, FileMode.Create, FileAccess.Write))
                    {
                        cryptoStream.CopyTo(decryptedFileStream);
                    }
                }
            }
        }
        public byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public void SaveKeyIV(string folderPath, string keyHex, string ivHex)
        {
            var keyIV = new
            {
                Key = keyHex,
                IV = ivHex
            };

            string json = JsonConvert.SerializeObject(keyIV);

            File.WriteAllText(Path.Combine(folderPath, "key_iv_rijndael" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".json"), json);
        }

        public string GetFileExtension()
        {
            return ".rij";
        }
    }
}
