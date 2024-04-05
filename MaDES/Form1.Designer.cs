namespace MaDES
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlFileOriginal = new System.Windows.Forms.TextBox();
            this.urlEncyptFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseFileOriginal = new System.Windows.Forms.Button();
            this.btnChooseFileEncrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtKeyHexa = new System.Windows.Forms.TextBox();
            this.txtIVHexa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoadKeyIV = new System.Windows.Forms.Button();
            this.btnSaveKeyK = new System.Windows.Forms.Button();
            this.btnCreateKeyIV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listEncryptType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // urlFileOriginal
            // 
            this.urlFileOriginal.Location = new System.Drawing.Point(164, 227);
            this.urlFileOriginal.Name = "urlFileOriginal";
            this.urlFileOriginal.ReadOnly = true;
            this.urlFileOriginal.Size = new System.Drawing.Size(483, 22);
            this.urlFileOriginal.TabIndex = 1;
            // 
            // urlEncyptFile
            // 
            this.urlEncyptFile.Location = new System.Drawing.Point(164, 264);
            this.urlEncyptFile.Name = "urlEncyptFile";
            this.urlEncyptFile.ReadOnly = true;
            this.urlEncyptFile.Size = new System.Drawing.Size(483, 22);
            this.urlEncyptFile.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "File ban đầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "File xử lý";
            // 
            // btnChooseFileOriginal
            // 
            this.btnChooseFileOriginal.Location = new System.Drawing.Point(668, 224);
            this.btnChooseFileOriginal.Name = "btnChooseFileOriginal";
            this.btnChooseFileOriginal.Size = new System.Drawing.Size(95, 29);
            this.btnChooseFileOriginal.TabIndex = 3;
            this.btnChooseFileOriginal.Text = "Chọn file...";
            this.btnChooseFileOriginal.UseVisualStyleBackColor = true;
            this.btnChooseFileOriginal.Click += new System.EventHandler(this.btnChooseFileOriginal_Click);
            // 
            // btnChooseFileEncrypt
            // 
            this.btnChooseFileEncrypt.Location = new System.Drawing.Point(668, 262);
            this.btnChooseFileEncrypt.Name = "btnChooseFileEncrypt";
            this.btnChooseFileEncrypt.Size = new System.Drawing.Size(95, 28);
            this.btnChooseFileEncrypt.TabIndex = 3;
            this.btnChooseFileEncrypt.Text = "Chọn file...";
            this.btnChooseFileEncrypt.UseVisualStyleBackColor = true;
            this.btnChooseFileEncrypt.Click += new System.EventHandler(this.btnChooseFileEncrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(263, 304);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(113, 41);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Mã hóa";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(432, 304);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(113, 41);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Giải mã";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtKeyHexa
            // 
            this.txtKeyHexa.Location = new System.Drawing.Point(245, 78);
            this.txtKeyHexa.Name = "txtKeyHexa";
            this.txtKeyHexa.Size = new System.Drawing.Size(518, 22);
            this.txtKeyHexa.TabIndex = 6;
            // 
            // txtIVHexa
            // 
            this.txtIVHexa.Location = new System.Drawing.Point(245, 122);
            this.txtIVHexa.Name = "txtIVHexa";
            this.txtIVHexa.Size = new System.Drawing.Size(518, 22);
            this.txtIVHexa.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Khóa (dạng hexa)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "IV (dạng hexa)";
            // 
            // btnLoadKeyIV
            // 
            this.btnLoadKeyIV.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadKeyIV.Location = new System.Drawing.Point(263, 166);
            this.btnLoadKeyIV.Name = "btnLoadKeyIV";
            this.btnLoadKeyIV.Size = new System.Drawing.Size(151, 37);
            this.btnLoadKeyIV.TabIndex = 8;
            this.btnLoadKeyIV.Text = "Nạp khóa && IV";
            this.btnLoadKeyIV.UseVisualStyleBackColor = true;
            this.btnLoadKeyIV.Click += new System.EventHandler(this.btnLoadKeyIV_Click);
            // 
            // btnSaveKeyK
            // 
            this.btnSaveKeyK.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveKeyK.Location = new System.Drawing.Point(430, 166);
            this.btnSaveKeyK.Name = "btnSaveKeyK";
            this.btnSaveKeyK.Size = new System.Drawing.Size(151, 37);
            this.btnSaveKeyK.TabIndex = 8;
            this.btnSaveKeyK.Text = "Lưu khóa && IV";
            this.btnSaveKeyK.UseVisualStyleBackColor = true;
            this.btnSaveKeyK.Click += new System.EventHandler(this.btnSaveKeyK_Click);
            // 
            // btnCreateKeyIV
            // 
            this.btnCreateKeyIV.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateKeyIV.Location = new System.Drawing.Point(601, 166);
            this.btnCreateKeyIV.Name = "btnCreateKeyIV";
            this.btnCreateKeyIV.Size = new System.Drawing.Size(151, 37);
            this.btnCreateKeyIV.TabIndex = 8;
            this.btnCreateKeyIV.Text = "Sinh khóa && IV";
            this.btnCreateKeyIV.UseVisualStyleBackColor = true;
            this.btnCreateKeyIV.Click += new System.EventHandler(this.btnCreateKeyIV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn thuật toán giải mã";
            // 
            // listEncryptType
            // 
            this.listEncryptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listEncryptType.FormattingEnabled = true;
            this.listEncryptType.Items.AddRange(new object[] {
            "AES",
            "DES",
            "Rijndael",
            "TrippleDES"});
            this.listEncryptType.Location = new System.Drawing.Point(245, 31);
            this.listEncryptType.Name = "listEncryptType";
            this.listEncryptType.Size = new System.Drawing.Size(144, 24);
            this.listEncryptType.Sorted = true;
            this.listEncryptType.TabIndex = 5;
            this.listEncryptType.SelectedIndexChanged += new System.EventHandler(this.listEncryptType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 367);
            this.Controls.Add(this.btnCreateKeyIV);
            this.Controls.Add(this.btnSaveKeyK);
            this.Controls.Add(this.btnLoadKeyIV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIVHexa);
            this.Controls.Add(this.txtKeyHexa);
            this.Controls.Add(this.listEncryptType);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnChooseFileEncrypt);
            this.Controls.Add(this.btnChooseFileOriginal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlEncyptFile);
            this.Controls.Add(this.urlFileOriginal);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "3.12.4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox urlFileOriginal;
        private System.Windows.Forms.TextBox urlEncyptFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChooseFileOriginal;
        private System.Windows.Forms.Button btnChooseFileEncrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtKeyHexa;
        private System.Windows.Forms.TextBox txtIVHexa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadKeyIV;
        private System.Windows.Forms.Button btnSaveKeyK;
        private System.Windows.Forms.Button btnCreateKeyIV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox listEncryptType;
    }
}

