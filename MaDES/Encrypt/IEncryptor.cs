namespace MaDES.Encrypt
{
    public interface IEncryptor
    {
        string GenerateKey();
        string GenerateIV();
        void EncryptFile(string filePath, string encryptedFilePath, string key, string iv);
        void DecryptFile(string encryptedFilePath, string decryptedFilePath, string key, string iv);
        void SaveKeyIV(string folderPath, string keyHex, string ivHex);
        string GetFileExtension();
    }
}
