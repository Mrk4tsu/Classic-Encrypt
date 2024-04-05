using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MaDES.Encrypt
{
    public class TripleDesEncrypt : IEncryptor
    {
        public static TripleDesEncrypt instance { get; } = new TripleDesEncrypt();

        public string GenerateKey()
        {
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.GenerateKey();

                string key = BitConverter.ToString(tripleDES.Key).Replace("-", "");
                return key.ToLower();
            }
        }

        public string GenerateIV()
        {
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.GenerateIV();

                string iv = BitConverter.ToString(tripleDES.IV).Replace("-", "");
                return iv.ToLower();
            }
        }

        public void EncryptFile(string filePath, string encryptedFilePath, string key, string iv)
        {
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.Key = StringToByteArray(key);
                tripleDES.IV = StringToByteArray(iv);

                ICryptoTransform encryptor = tripleDES.CreateEncryptor(tripleDES.Key, tripleDES.IV);

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
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.Key = StringToByteArray(key);
                tripleDES.IV = StringToByteArray(iv);

                ICryptoTransform decryptor = tripleDES.CreateDecryptor(tripleDES.Key, tripleDES.IV);

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

            File.WriteAllText(Path.Combine(folderPath, "key_iv_triple_des" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".json"), json);
        }

        public string GetFileExtension()
        {
            return ".tdes";
        }
    }
}
