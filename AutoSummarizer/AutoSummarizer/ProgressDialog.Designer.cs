namespace AutoSummarizer
{
    partial class ProgressDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressDialog));
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressbar
            // 
            this.progressbar.Location = new System.Drawing.Point(19, 21);
            this.progressbar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(492, 42);
            this.progressbar.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(215, 79);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(87, 21);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "waiting...";
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 117);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "진행중";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressbar;
        private System.Windows.Forms.Label lblStatus;
    }
}