namespace AppCHAT
{
    partial class file
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(file));
            this.cbxCompress = new System.Windows.Forms.CheckBox();
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // cbxCompress
            // 
            this.cbxCompress.AutoSize = true;
            this.cbxCompress.Location = new System.Drawing.Point(487, 10);
            this.cbxCompress.Name = "cbxCompress";
            this.cbxCompress.Size = new System.Drawing.Size(123, 24);
            this.cbxCompress.TabIndex = 13;
            this.cbxCompress.Text = "Compress File";
            this.cbxCompress.UseVisualStyleBackColor = true;
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(2, 8);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.Size = new System.Drawing.Size(478, 27);
            this.tbxFile.TabIndex = 12;
            this.tbxFile.Text = "Click to select file";
            this.tbxFile.Click += new System.EventHandler(this.tbxFile_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(477, 25);
            this.progressBar1.TabIndex = 11;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(487, 36);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(118, 27);
            this.btnSendFile.TabIndex = 10;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFileFile_Click);
            // 
            // imageList3
            // 
            this.imageList3.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "Picture17.png");
            // 
            // file
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 70);
            this.Controls.Add(this.cbxCompress);
            this.Controls.Add(this.tbxFile);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSendFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "file";
            this.Text = "file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox cbxCompress;
        private TextBox tbxFile;
        private ProgressBar progressBar1;
        private Button btnSendFile;
        private ImageList imageList3;
    }
}