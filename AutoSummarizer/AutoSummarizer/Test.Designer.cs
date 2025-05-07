namespace AutoSummarizer
{
    partial class Test
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
            this.textBox_Test = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox_Test
            // 
            this.textBox_Test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Test.Location = new System.Drawing.Point(0, 0);
            this.textBox_Test.Name = "textBox_Test";
            this.textBox_Test.Size = new System.Drawing.Size(370, 220);
            this.textBox_Test.TabIndex = 0;
            this.textBox_Test.Text = "";
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 220);
            this.Controls.Add(this.textBox_Test);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox_Test;
    }
}