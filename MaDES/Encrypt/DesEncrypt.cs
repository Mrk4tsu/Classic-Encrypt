using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MaDES.Encrypt
{
    public class DesEncrypt : IEncryptor
    {
        public static DesEncrypt instance { get; } = new DesEncrypt();
        public object GetKey(string jsonFile)
        {
            var keyIV = JsonConvert.DeserializeObject<dynamic>(jsonFile);
            return keyIV.Key;
        }
        public object GetIV(string jsonFile)
        {
            var keyIV = JsonConvert.DeserializeObject<dynamic>(jsonFile);
            return keyIV.IV;
        }
        public string GenerateKey()
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.GenerateKey();

                string key = BitConverter.ToString(des.Key).Replace("-", "");
                return key.ToLower();
            }
        }
        public string GenerateIV()
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.GenerateIV();

                string iv = BitConverter.ToString(des.IV).Replace("-", "");
                return iv.ToLower();
            }
        }
        public void EncryptFile(string filePath, string encryptedFilePath, string key, string iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = StringToByteArray(key);
                des.IV = StringToByteArray(iv);

                ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);

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
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = StringToByteArray(key);
                des.IV = StringToByteArray(iv);

                ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV);

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

            File.WriteAllText(Path.Combine(folderPath, "key_iv_des" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".json"), json);

        }

        public string GetFileExtension()
        {
            return ".des";
        }
    }
}
