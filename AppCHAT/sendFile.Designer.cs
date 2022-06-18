namespace AppCHAT
{
    partial class sendFile
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
            this.tbxIp = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbxCompress = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbxIp
            // 
            this.tbxIp.Location = new System.Drawing.Point(76, 15);
            this.tbxIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxIp.Name = "tbxIp";
            this.tbxIp.Size = new System.Drawing.Size(375, 27);
            this.tbxIp.TabIndex = 0;
            this.tbxIp.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 148);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(436, 29);
            this.progressBar1.TabIndex = 2;
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(76, 47);
            this.tbxFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.ReadOnly = true;
            this.tbxFile.Size = new System.Drawing.Size(375, 27);
            this.tbxFile.TabIndex = 3;
            this.tbxFile.TabStop = false;
            this.tbxFile.Text = "Click to select file";
            this.tbxFile.Click += new System.EventHandler(this.textBox2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dest IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "File";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(15, 112);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(436, 28);
            this.btnSend.TabIndex = 6;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxCompress
            // 
            this.cbxCompress.AutoSize = true;
            this.cbxCompress.Location = new System.Drawing.Point(77, 77);
            this.cbxCompress.Name = "cbxCompress";
            this.cbxCompress.Size = new System.Drawing.Size(123, 24);
            this.cbxCompress.TabIndex = 7;
            this.cbxCompress.Text = "Compress File";
            this.cbxCompress.UseVisualStyleBackColor = true;
            // 
            // sendFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 187);
            this.Controls.Add(this.cbxCompress);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxFile);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tbxIp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "sendFile";
            this.Text = "FileSender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxIp;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private CheckBox cbxCompress;
    }
}