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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.pnl2 = new System.Windows.Forms.Panel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnBuddy = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pnl1.Controls.Add(this.pictureBox1);
            this.pnl1.Location = new System.Drawing.Point(5, 7);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(160, 490);
            this.pnl1.TabIndex = 0;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Location = new System.Drawing.Point(7, 452);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(54, 20);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "Your IP";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(7, 434);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 18);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Your Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImage = global::AppCHAT.Properties.Resources.Picture15;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSetting.Location = new System.Drawing.Point(0, 260);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(160, 105);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "HISTORY";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnFile
            // 
            this.btnFile.BackgroundImage = global::AppCHAT.Properties.Resources.Picture14;
            this.btnFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFile.FlatAppearance.BorderSize = 0;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFile.Location = new System.Drawing.Point(0, 155);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(160, 105);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "FILES";
            this.btnFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnBuddy
            // 
            this.btnBuddy.BackgroundImage = global::AppCHAT.Properties.Resources.Picture13;
            this.btnBuddy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuddy.FlatAppearance.BorderSize = 0;
            this.btnBuddy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuddy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuddy.Location = new System.Drawing.Point(0, 50);
            this.btnBuddy.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuddy.Name = "btnBuddy";
            this.btnBuddy.Size = new System.Drawing.Size(160, 105);
            this.btnBuddy.TabIndex = 0;
            this.btnBuddy.Text = "BUDDY";
            this.btnBuddy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuddy.UseVisualStyleBackColor = true;
            this.btnBuddy.Click += new System.EventHandler(this.btnBuddy_Click);
            this.btnBuddy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnBuddy_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AppCHAT.Properties.Resources.Picture16;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 419);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 63);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Picture10.png");
            this.imageList2.Images.SetKeyName(1, "Picture11.png");
            this.imageList2.Images.SetKeyName(2, "Picture12.png");
            this.imageList2.Images.SetKeyName(3, "Picture13.png");
            this.imageList2.Images.SetKeyName(4, "Picture14.png");
            this.imageList2.Images.SetKeyName(5, "Picture15.png");
            this.imageList2.Images.SetKeyName(6, "Picture17.png");
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private ImageList imageList2;
        private PictureBox pictureBox1;
    }
}