
namespace Steganography
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.src = new System.Windows.Forms.TextBox();
            this.download = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.text1 = new System.Windows.Forms.TextBox();
            this.text2 = new System.Windows.Forms.TextBox();
            this.coding = new System.Windows.Forms.Button();
            this.decoding = new System.Windows.Forms.Button();
            this.downloadDec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            this.SuspendLayout();
            // 
            // src
            // 
            this.src.Location = new System.Drawing.Point(16, 12);
            this.src.Name = "src";
            this.src.Size = new System.Drawing.Size(532, 22);
            this.src.TabIndex = 0;
            // 
            // download
            // 
            this.download.Location = new System.Drawing.Point(554, 8);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(121, 31);
            this.download.TabIndex = 1;
            this.download.Text = "Загрузить";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(1215, 8);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(121, 31);
            this.save.TabIndex = 2;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // picture1
            // 
            this.picture1.Location = new System.Drawing.Point(16, 45);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(657, 420);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture1.TabIndex = 3;
            this.picture1.TabStop = false;
            // 
            // picture2
            // 
            this.picture2.Location = new System.Drawing.Point(679, 45);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(657, 420);
            this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture2.TabIndex = 5;
            this.picture2.TabStop = false;
            // 
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(16, 475);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(486, 22);
            this.text1.TabIndex = 6;
            // 
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(679, 475);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(486, 22);
            this.text2.TabIndex = 7;
            // 
            // coding
            // 
            this.coding.Location = new System.Drawing.Point(508, 471);
            this.coding.Name = "coding";
            this.coding.Size = new System.Drawing.Size(121, 31);
            this.coding.TabIndex = 8;
            this.coding.Text = "Зашифровать";
            this.coding.UseVisualStyleBackColor = true;
            this.coding.Click += new System.EventHandler(this.coding_Click);
            // 
            // decoding
            // 
            this.decoding.Location = new System.Drawing.Point(1171, 470);
            this.decoding.Name = "decoding";
            this.decoding.Size = new System.Drawing.Size(121, 31);
            this.decoding.TabIndex = 9;
            this.decoding.Text = "Расшифровать";
            this.decoding.UseVisualStyleBackColor = true;
            this.decoding.Click += new System.EventHandler(this.decoding_Click);
            // 
            // downloadDec
            // 
            this.downloadDec.Location = new System.Drawing.Point(681, 8);
            this.downloadDec.Name = "downloadDec";
            this.downloadDec.Size = new System.Drawing.Size(231, 31);
            this.downloadDec.TabIndex = 11;
            this.downloadDec.Text = "Загрузить для расшифрования";
            this.downloadDec.UseVisualStyleBackColor = true;
            this.downloadDec.Click += new System.EventHandler(this.downloadDec_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 513);
            this.Controls.Add(this.downloadDec);
            this.Controls.Add(this.decoding);
            this.Controls.Add(this.coding);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.picture1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.download);
            this.Controls.Add(this.src);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox src;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.PictureBox picture2;
        private System.Windows.Forms.TextBox text1;
        private System.Windows.Forms.TextBox text2;
        private System.Windows.Forms.Button coding;
        private System.Windows.Forms.Button decoding;
        private System.Windows.Forms.Button downloadDec;
    }
}

