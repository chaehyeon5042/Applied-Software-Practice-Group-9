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
            this.picBox_Report = new System.Windows.Forms.PictureBox();
            this.picBox_Study = new System.Windows.Forms.PictureBox();
            this.picBox_Pre = new System.Windows.Forms.PictureBox();
            this.rdoReport = new System.Windows.Forms.RadioButton();
            this.rdoStudy = new System.Windows.Forms.RadioButton();
            this.rdoPresentation = new System.Windows.Forms.RadioButton();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.grpBox_Pre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Study)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Pre)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBox_Pre
            // 
            this.grpBox_Pre.Controls.Add(this.picBox_Report);
            this.grpBox_Pre.Controls.Add(this.picBox_Study);
            this.grpBox_Pre.Controls.Add(this.picBox_Pre);
            this.grpBox_Pre.Controls.Add(this.rdoReport);
            this.grpBox_Pre.Controls.Add(this.rdoStudy);
            this.grpBox_Pre.Controls.Add(this.rdoPresentation);
            this.grpBox_Pre.Location = new System.Drawing.Point(13, 13);
            this.grpBox_Pre.Name = "grpBox_Pre";
            this.grpBox_Pre.Size = new System.Drawing.Size(775, 361);
            this.grpBox_Pre.TabIndex = 0;
            this.grpBox_Pre.TabStop = false;
            this.grpBox_Pre.Text = "Preview";
            // 
            // picBox_Report
            // 
            this.picBox_Report.Location = new System.Drawing.Point(540, 40);
            this.picBox_Report.Name = "picBox_Report";
            this.picBox_Report.Size = new System.Drawing.Size(209, 271);
            this.picBox_Report.TabIndex = 5;
            this.picBox_Report.TabStop = false;
            // 
            // picBox_Study
            // 
            this.picBox_Study.Location = new System.Drawing.Point(280, 38);
            this.picBox_Study.Name = "picBox_Study";
            this.picBox_Study.Size = new System.Drawing.Size(209, 273);
            this.picBox_Study.TabIndex = 4;
            this.picBox_Study.TabStop = false;
            // 
            // picBox_Pre
            // 
            this.picBox_Pre.Location = new System.Drawing.Point(21, 37);
            this.picBox_Pre.Name = "picBox_Pre";
            this.picBox_Pre.Size = new System.Drawing.Size(209, 274);
            this.picBox_Pre.TabIndex = 3;
            this.picBox_Pre.TabStop = false;
            // 
            // rdoReport
            // 
            this.rdoReport.AutoSize = true;
            this.rdoReport.Location = new System.Drawing.Point(561, 317);
            this.rdoReport.Name = "rdoReport";
            this.rdoReport.Size = new System.Drawing.Size(166, 25);
            this.rdoReport.TabIndex = 2;
            this.rdoReport.TabStop = true;
            this.rdoReport.Text = "보고서(Report)";
            this.rdoReport.UseVisualStyleBackColor = true;
            this.rdoReport.CheckedChanged += new System.EventHandler(this.rdoBtn_CheckedChanged);
            // 
            // rdoStudy
            // 
            this.rdoStudy.AutoSize = true;
            this.rdoStudy.Location = new System.Drawing.Point(309, 317);
            this.rdoStudy.Name = "rdoStudy";
            this.rdoStudy.Size = new System.Drawing.Size(159, 25);
            this.rdoStudy.TabIndex = 1;
            this.rdoStudy.TabStop = true;
            this.rdoStudy.Text = "학습용(Study)";
            this.rdoStudy.UseVisualStyleBackColor = true;
            this.rdoStudy.CheckedChanged += new System.EventHandler(this.rdoBtn_CheckedChanged);
            // 
            // rdoPresentation
            // 
            this.rdoPresentation.AutoSize = true;
            this.rdoPresentation.Location = new System.Drawing.Point(21, 317);
            this.rdoPresentation.Name = "rdoPresentation";
            this.rdoPresentation.Size = new System.Drawing.Size(209, 25);
            this.rdoPresentation.TabIndex = 0;
            this.rdoPresentation.TabStop = true;
            this.rdoPresentation.Text = "발표용(Presentaion)";
            this.rdoPresentation.UseVisualStyleBackColor = true;
            this.rdoPresentation.CheckedChanged += new System.EventHandler(this.rdoBtn_CheckedChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(34, 401);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(230, 49);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(283, 401);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(230, 49);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(532, 402);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(230, 48);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.grpBox_Pre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreviewForm";
            this.Text = "Auto Summarizer";
            this.grpBox_Pre.ResumeLayout(false);
            this.grpBox_Pre.PerformLayout();
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
    }
}