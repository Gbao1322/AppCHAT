namespace AppCHAT
{
    partial class history
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
            this.pnlChat = new System.Windows.Forms.Panel();
            this.pnlBuddy = new System.Windows.Forms.Panel();
            this.btnScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.Color.White;
            this.pnlChat.Location = new System.Drawing.Point(145, 0);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(610, 490);
            this.pnlChat.TabIndex = 6;
            // 
            // pnlBuddy
            // 
            this.pnlBuddy.Location = new System.Drawing.Point(2, 49);
            this.pnlBuddy.Name = "pnlBuddy";
            this.pnlBuddy.Size = new System.Drawing.Size(140, 440);
            this.pnlBuddy.TabIndex = 5;
            // 
            // btnScan
            // 
            this.btnScan.BackgroundImage = global::AppCHAT.Properties.Resources.refresh;
            this.btnScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScan.Location = new System.Drawing.Point(34, -1);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(82, 45);
            this.btnScan.TabIndex = 4;
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(755, 490);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.pnlBuddy);
            this.Controls.Add(this.btnScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "history";
            this.Text = "setting";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlChat;
        private Panel pnlBuddy;
        private Button btnScan;
    }
}