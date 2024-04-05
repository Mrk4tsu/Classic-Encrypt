using MaDES.Encrypt;
using MaDES.Utils;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace MaDES
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.listEncryptType.SelectedIndex = 0;

            //worker.WorkerReportsProgress = true;
            //worker.DoWork += worker_DoWork;
            //worker.ProgressChanged += worker_ProgressChanged;
            //worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void btnChooseFileOriginal_Click(object sender, EventArgs e)
        {
            try
            {
                string filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                string filePath = FolderUtilities.instance.GetUrlFile(filter);

               

                string lastExtension = Path.GetExtension(filePath);
                string pathFileExport = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + currentEncryptor.GetFileExtension());
                if (lastExtension.Contains(currentEncryptor.GetFileExtension()))
                {
                    pathFileExport = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath));
                }
                else
                {
                    pathFileExport = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + currentEncryptor.GetFileExtension());
                }

                // Display the file path in textbox
                urlFileOriginal.Text = filePath;

                // Display the encrypted file path in textbox
                urlEncyptFile.Text = pathFileExport;
            }
            catch
            {
            }
        }
        private void btnChooseFileEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = FolderUtilities.instance.GetUrlFolder();
                urlEncyptFile.Text = Path.Combine(folderPath, Path.GetFileName(urlEncyptFile.Text));
            }
            catch
            {
            }
           
        }
        private void btnCreateKeyIV_Click(object sender, EventArgs e)
        {
            txtIVHexa.Text = currentEncryptor.GenerateIV();
            txtKeyHexa.Text = currentEncryptor.GenerateKey();
        }

        private void btnSaveKeyK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreKeyAndIVProvided())
                {
                    return;
                }
                string folderPath = FolderUtilities.instance.GetUrlFolder();
                string keyHex = txtKeyHexa.Text;
                string ivHex = txtIVHexa.Text;

                currentEncryptor.SaveKeyIV(folderPath, keyHex, ivHex);

                MessageBox.Show("Đã lưu thành công.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
            }
        }

        private void btnLoadKeyIV_Click(object sender, EventArgs e)
        {
            string filePath = FolderUtilities.instance.GetUrlFile("json files (*.json)|*.json");
            try
            {
                // Đọc dữ liệu từ file JSON
                string json = File.ReadAllText(filePath);

                // Convert the JSON string to an object
                var keyIV = JsonConvert.DeserializeObject<dynamic>(json);

                // Hiển thị key và IV lên textbox
                txtKeyHexa.Text = keyIV.Key;
                txtIVHexa.Text = keyIV.IV;
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreKeyAndIVProvided())
                {
                    return;
                }
                string originalFilePath = urlFileOriginal.Text;
                string encryptFilePath = urlEncyptFile.Text;
                string keyHex = txtKeyHexa.Text;
                string ivHex = txtIVHexa.Text;

                currentEncryptor.EncryptFile(originalFilePath, encryptFilePath, keyHex, ivHex);
                //File.Copy(encryptFilePath, encryptFilePath + currentEncryptor.GetFileExtension());

                MessageBox.Show("Mã hóa thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể mã hóa, vui lòng kiểm tra lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreKeyAndIVProvided())
                {
                    return;
                }
                string encryptedFilePath = urlFileOriginal.Text;
                string decryptedFilePath = urlEncyptFile.Text.Replace("_encrypted", "_decrypted");
                string keyHex = txtKeyHexa.Text;
                string ivHex = txtIVHexa.Text;

                if (Path.GetExtension(encryptedFilePath) != currentEncryptor.GetFileExtension())
                {
                    MessageBox.Show("Đuôi file không phù hợp với phương thức mã hóa đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decryptedFilePath = Path.ChangeExtension(decryptedFilePath, null);

                currentEncryptor.DecryptFile(encryptedFilePath, decryptedFilePath, keyHex, ivHex);

                MessageBox.Show("Giải mã thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể giải mã, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool AreKeyAndIVProvided()
        {
            string keyHex = txtKeyHexa.Text;
            string ivHex = txtIVHexa.Text;

            if (string.IsNullOrEmpty(keyHex) || string.IsNullOrEmpty(ivHex))
            {
                MessageBox.Show("Key hoặc IV không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private IEncryptor currentEncryptor;
        private void listEncryptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIVHexa.Clear();
            txtKeyHexa.Clear();

            string selectedMethod = (string)listEncryptType.SelectedItem;

            if (selectedMethod == "AES")
            {
                currentEncryptor = AesEncrypt.instance;
            }
            else if (selectedMethod == "DES")
            {
                currentEncryptor = DesEncrypt.instance;
            }
            else if (selectedMethod == "Rijndael")
            {
                currentEncryptor = RijndaelEncrypt.instance;
            }
            else if (selectedMethod == "TrippleDES")
            {
                currentEncryptor = TripleDesEncrypt.instance;
            }
        }
    }
}
