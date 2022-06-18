namespace AppCHAT
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl2 = new System.Windows.Forms.Panel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnBuddy = new System.Windows.Forms.Button();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnl2.Location = new System.Drawing.Point(171, 7);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(755, 490);
            this.pnl2.TabIndex = 0;
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnl1.Controls.Add(this.lblIP);
            this.pnl1.Controls.Add(this.lblName);
            this.pnl1.Controls.Add(this.btnSetting);
            this.pnl1.Controls.Add(this.btnFile);
            this.pnl1.Controls.Add(this.btnBuddy);
            this.pnl1.Location = new System.Drawing.Point(5, 7);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(160, 490);
            this.pnl1.TabIndex = 0;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(9, 405);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(54, 20);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "Your IP";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 368);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Your Name";
            // 
            // btnSetting
            // 
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSetting.Location = new System.Drawing.Point(0, 260);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(160, 105);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "HISTORY";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnFile
            // 
            this.btnFile.FlatAppearance.BorderSize = 0;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFile.Location = new System.Drawing.Point(0, 155);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(160, 105);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "FILES";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnBuddy
            // 
            this.btnBuddy.FlatAppearance.BorderSize = 0;
            this.btnBuddy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuddy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuddy.Location = new System.Drawing.Point(0, 50);
            this.btnBuddy.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuddy.Name = "btnBuddy";
            this.btnBuddy.Size = new System.Drawing.Size(160, 105);
            this.btnBuddy.TabIndex = 0;
            this.btnBuddy.Text = "BUDDY";
            this.btnBuddy.UseVisualStyleBackColor = true;
            this.btnBuddy.Click += new System.EventHandler(this.btnBuddy_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(932, 503);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.Load += new System.EventHandler(this.main_Load);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnl1;
        private Button btnSetting;
        private Button btnFile;
        private Button btnBuddy;
        public Label lblName;
        public Label lblIP;
        public Panel pnl2;
    }
}