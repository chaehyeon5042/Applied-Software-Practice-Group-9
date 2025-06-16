namespace AutoSummarizer
{
    partial class PreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewForm));
            this.grpBox_Pre = new System.Windows.Forms.GroupBox();
            this.rdoReport = new System.Windows.Forms.RadioButton();
            this.rdoStudy = new System.Windows.Forms.RadioButton();
            this.rdoPresentation = new System.Windows.Forms.RadioButton();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBox_Report = new System.Windows.Forms.PictureBox();
            this.picBox_Study = new System.Windows.Forms.PictureBox();
            this.picBox_Pre = new System.Windows.Forms.PictureBox();
            this.grpBox_Pre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Study)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Pre)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBox_Pre
            // 
            this.grpBox_Pre.Controls.Add(this.pictureBox3);
            this.grpBox_Pre.Controls.Add(this.pictureBox2);
            this.grpBox_Pre.Controls.Add(this.pictureBox1);
            this.grpBox_Pre.Controls.Add(this.picBox_Report);
            this.grpBox_Pre.Controls.Add(this.picBox_Study);
            this.grpBox_Pre.Controls.Add(this.picBox_Pre);
            this.grpBox_Pre.Controls.Add(this.rdoReport);
            this.grpBox_Pre.Controls.Add(this.rdoStudy);
            this.grpBox_Pre.Controls.Add(this.rdoPresentation);
            this.grpBox_Pre.Location = new System.Drawing.Point(13, 12);
            this.grpBox_Pre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpBox_Pre.Name = "grpBox_Pre";
            this.grpBox_Pre.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpBox_Pre.Size = new System.Drawing.Size(1448, 757);
            this.grpBox_Pre.TabIndex = 0;
            this.grpBox_Pre.TabStop = false;
            this.grpBox_Pre.Text = "Preview";
            // 
            // rdoReport
            // 
            this.rdoReport.AutoSize = true;
            this.rdoReport.Location = new System.Drawing.Point(1136, 711);
            this.rdoReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoReport.Name = "rdoReport";
            this.rdoReport.Size = new System.Drawing.Size(166, 25);
            this.rdoReport.TabIndex = 2;
            this.rdoReport.TabStop = true;
            this.rdoReport.Text = "보고서(Report)";
            this.rdoReport.UseVisualStyleBackColor = true;
            // 
            // rdoStudy
            // 
            this.rdoStudy.AutoSize = true;
            this.rdoStudy.Location = new System.Drawing.Point(687, 711);
            this.rdoStudy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoStudy.Name = "rdoStudy";
            this.rdoStudy.Size = new System.Drawing.Size(159, 25);
            this.rdoStudy.TabIndex = 1;
            this.rdoStudy.TabStop = true;
            this.rdoStudy.Text = "학습용(Study)";
            this.rdoStudy.UseVisualStyleBackColor = true;
            // 
            // rdoPresentation
            // 
            this.rdoPresentation.AutoSize = true;
            this.rdoPresentation.Location = new System.Drawing.Point(164, 711);
            this.rdoPresentation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoPresentation.Name = "rdoPresentation";
            this.rdoPresentation.Size = new System.Drawing.Size(209, 25);
            this.rdoPresentation.TabIndex = 0;
            this.rdoPresentation.TabStop = true;
            this.rdoPresentation.Text = "발표용(Presentaion)";
            this.rdoPresentation.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(391, 802);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(229, 49);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(627, 802);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(229, 49);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(862, 802);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(229, 47);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AutoSummarizer.Properties.Resources.PDF_Icon;
            this.pictureBox3.Location = new System.Drawing.Point(1189, 641);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AutoSummarizer.Properties.Resources.PDF_Icon;
            this.pictureBox2.Location = new System.Drawing.Point(744, 641);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoSummarizer.Properties.Resources.PPT_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(250, 641);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // picBox_Report
            // 
            this.picBox_Report.Location = new System.Drawing.Point(1000, 33);
            this.picBox_Report.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBox_Report.Name = "picBox_Report";
            this.picBox_Report.Size = new System.Drawing.Size(420, 594);
            this.picBox_Report.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_Report.TabIndex = 5;
            this.picBox_Report.TabStop = false;
            // 
            // picBox_Study
            // 
            this.picBox_Study.Location = new System.Drawing.Point(553, 33);
            this.picBox_Study.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBox_Study.Name = "picBox_Study";
            this.picBox_Study.Size = new System.Drawing.Size(420, 594);
            this.picBox_Study.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_Study.TabIndex = 4;
            this.picBox_Study.TabStop = false;
            // 
            // picBox_Pre
            // 
            this.picBox_Pre.Location = new System.Drawing.Point(26, 143);
            this.picBox_Pre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBox_Pre.Name = "picBox_Pre";
            this.picBox_Pre.Size = new System.Drawing.Size(500, 375);
            this.picBox_Pre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_Pre.TabIndex = 3;
            this.picBox_Pre.TabStop = false;
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 873);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.grpBox_Pre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Summarizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreviewForm_FormClosed);
            this.grpBox_Pre.ResumeLayout(false);
            this.grpBox_Pre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Study)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Pre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox_Pre;
        private System.Windows.Forms.RadioButton rdoReport;
        private System.Windows.Forms.RadioButton rdoStudy;
        private System.Windows.Forms.RadioButton rdoPresentation;
        private System.Windows.Forms.PictureBox picBox_Report;
        private System.Windows.Forms.PictureBox picBox_Study;
        private System.Windows.Forms.PictureBox picBox_Pre;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}