using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MaDES.Encrypt
{
    public class AesEncrypt : IEncryptor
    {
        public static AesEncrypt instance { get; } = new AesEncrypt();
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
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                
                string key = BitConverter.ToString(aes.Key).Replace("-", "");               
                return key.ToLower();
            }
        }
        public string GenerateIV()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();

                string iv = BitConverter.ToString(aes.IV).Replace("-", "");
                return iv.ToLower();
            }
        }
        public void EncryptFile(string filePath, string encryptedFilePath, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = StringToByteArray(key);
                aes.IV = StringToByteArray(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (FileStream originalFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (CryptoStream cryptoStream = new CryptoStream(originalFileStream, encryptor, CryptoStreamMode.Read))
                {
                    using (FileStream encryptedFileStream = new FileStream(encryptedFilePath, FileMode.Create, FileAccess.Write))
                    {
                        // Sao chép dữ liệu mã hóa vào file đích
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
        [EncryptMethod("AES")]
        public void DecryptFile(string encryptedFilePath, string decryptedFilePath, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = StringToByteArray(key);
                aes.IV = StringToByteArray(iv);

                // Tạo bộ giải mã
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (FileStream encryptedFileStream = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read))
                using (CryptoStream cryptoStream = new CryptoStream(encryptedFileStream, decryptor, CryptoStreamMode.Read))
                {
                    using (FileStream decryptedFileStream = new FileStream(decryptedFilePath, FileMode.Create, FileAccess.Write))
                    {
                        // Sao chép dữ liệu giải mã vào file đích
                        cryptoStream.CopyTo(decryptedFileStream);
                    }
                }
            }
                
        }
        public byte[] StringToByteArray(string hex)
        {
            //int numberChars = hex.Length;
            //byte[] bytes = new byte[numberChars / 2];
            //for (int i = 0; i < numberChars; i += 2)
            //{
            //    bytes[i / 2] = byte.Parse(hex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            //}
            return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();
        }
        public void SaveKeyIV(string folderPath, string keyHex, string ivHex)
        {
            // Lưu key và IV vào object
            var keyIV = new
            {
                Key = keyHex,
                IV = ivHex
            };

            // Chuyển đổi object sang chuỗi json
            string json = JsonConvert.SerializeObject(keyIV);

            //Ghi file json
            File.WriteAllText(Path.Combine(folderPath, "key_iv_aes" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".json"), json);

        }

        public string GetFileExtension()
        {
            return ".aes";
        }
    }
}
