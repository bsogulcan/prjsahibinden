namespace DataCollector
{
    partial class frmMain
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
            this.gbWebBrowser = new System.Windows.Forms.GroupBox();
            this.gbLogs = new System.Windows.Forms.GroupBox();
            this.memoLogs = new System.Windows.Forms.RichTextBox();
            this.gbLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbWebBrowser
            // 
            this.gbWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.gbWebBrowser.Name = "gbWebBrowser";
            this.gbWebBrowser.Size = new System.Drawing.Size(1169, 479);
            this.gbWebBrowser.TabIndex = 0;
            this.gbWebBrowser.TabStop = false;
            this.gbWebBrowser.Text = "WebBrowser";
            // 
            // gbLogs
            // 
            this.gbLogs.Controls.Add(this.memoLogs);
            this.gbLogs.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbLogs.Location = new System.Drawing.Point(734, 0);
            this.gbLogs.Name = "gbLogs";
            this.gbLogs.Size = new System.Drawing.Size(435, 479);
            this.gbLogs.TabIndex = 0;
            this.gbLogs.TabStop = false;
            this.gbLogs.Text = "Logs";
            // 
            // memoLogs
            // 
            this.memoLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoLogs.Location = new System.Drawing.Point(3, 23);
            this.memoLogs.Name = "memoLogs";
            this.memoLogs.Size = new System.Drawing.Size(429, 453);
            this.memoLogs.TabIndex = 0;
            this.memoLogs.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 479);
            this.Controls.Add(this.gbLogs);
            this.Controls.Add(this.gbWebBrowser);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.gbLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbWebBrowser;
        private System.Windows.Forms.GroupBox gbLogs;
        private System.Windows.Forms.RichTextBox memoLogs;
    }
}