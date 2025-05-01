namespace AutoSummarizer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AutoSumIcon = new System.Windows.Forms.PictureBox();
            this.btn_FileUpload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.btn_Gen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSumIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // AutoSumIcon
            // 
            this.AutoSumIcon.Image = global::AutoSummarizer.Properties.Resources.AutoSummarizerIcon;
            this.AutoSumIcon.Location = new System.Drawing.Point(13, 13);
            this.AutoSumIcon.Name = "AutoSumIcon";
            this.AutoSumIcon.Size = new System.Drawing.Size(200, 200);
            this.AutoSumIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AutoSumIcon.TabIndex = 0;
            this.AutoSumIcon.TabStop = false;
            // 
            // btn_FileUpload
            // 
            this.btn_FileUpload.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_FileUpload.Location = new System.Drawing.Point(520, 79);
            this.btn_FileUpload.Name = "btn_FileUpload";
            this.btn_FileUpload.Size = new System.Drawing.Size(154, 38);
            this.btn_FileUpload.TabIndex = 1;
            this.btn_FileUpload.Text = "파일 업로드";
            this.btn_FileUpload.UseVisualStyleBackColor = true;
            this.btn_FileUpload.Click += new System.EventHandler(this.btn_FileUpload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Auto Summarizer\r\n";
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(238, 81);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(276, 32);
            this.txt_FileName.TabIndex = 3;
            // 
            // btn_Gen
            // 
            this.btn_Gen.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gen.Location = new System.Drawing.Point(238, 137);
            this.btn_Gen.Name = "btn_Gen";
            this.btn_Gen.Size = new System.Drawing.Size(436, 76);
            this.btn_Gen.TabIndex = 4;
            this.btn_Gen.Text = "Generate";
            this.btn_Gen.UseVisualStyleBackColor = true;
            this.btn_Gen.Click += new System.EventHandler(this.btn_Gen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 227);
            this.Controls.Add(this.btn_Gen);
            this.Controls.Add(this.txt_FileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_FileUpload);
            this.Controls.Add(this.AutoSumIcon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Auto Summarizer";
            ((System.ComponentModel.ISupportInitialize)(this.AutoSumIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AutoSumIcon;
        private System.Windows.Forms.Button btn_FileUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Button btn_Gen;
    }
}

