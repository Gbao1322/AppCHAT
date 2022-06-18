namespace AppCHAT
{
    partial class buddy
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
            this.btnScan = new System.Windows.Forms.Button();
            this.pnlBuddy = new System.Windows.Forms.Panel();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.pnlFile = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(0, 0);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(140, 45);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "SCAN";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // pnlBuddy
            // 
            this.pnlBuddy.Location = new System.Drawing.Point(0, 50);
            this.pnlBuddy.Name = "pnlBuddy";
            this.pnlBuddy.Size = new System.Drawing.Size(140, 436);
            this.pnlBuddy.TabIndex = 2;
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlChat.Location = new System.Drawing.Point(145, 0);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(610, 410);
            this.pnlChat.TabIndex = 3;
            // 
            // pnlFile
            // 
            this.pnlFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFile.Location = new System.Drawing.Point(145, 416);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(610, 70);
            this.pnlFile.TabIndex = 3;
            // 
            // buddy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(755, 490);
            this.Controls.Add(this.pnlFile);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.pnlBuddy);
            this.Controls.Add(this.btnScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "buddy";
            this.Text = "buddy";
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnScan;
        private Panel pnlBuddy;
        private Panel pnlChat;
        private Panel pnlFile;
    }
}