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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbxCompress = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 36);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(202, 27);
            this.progressBar1.TabIndex = 2;
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(3, 4);
            this.tbxFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.ReadOnly = true;
            this.tbxFile.Size = new System.Drawing.Size(156, 27);
            this.tbxFile.TabIndex = 3;
            this.tbxFile.TabStop = false;
            this.tbxFile.Text = "Click to select file";
            this.tbxFile.Click += new System.EventHandler(this.tbxFile_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(211, 37);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 28);
            this.btnSend.TabIndex = 6;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "Send File";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSendFileFile_Click);
            // 
            // cbxCompress
            // 
            this.cbxCompress.AutoSize = true;
            this.cbxCompress.Location = new System.Drawing.Point(165, 6);
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
            this.ClientSize = new System.Drawing.Size(305, 70);
            this.Controls.Add(this.cbxCompress);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbxFile);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "sendFile";
            this.Text = "FileSender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Button btnSend;
        private CheckBox cbxCompress;
    }
}