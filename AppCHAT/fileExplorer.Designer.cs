namespace AppCHAT
{
    partial class fileExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileExplorer));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lFile = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDecompress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "audio.png");
            this.imageList1.Images.SetKeyName(1, "exe.png");
            this.imageList1.Images.SetKeyName(2, "video.png");
            this.imageList1.Images.SetKeyName(3, "pdf.png");
            this.imageList1.Images.SetKeyName(4, "doc.png");
            this.imageList1.Images.SetKeyName(5, "img.png");
            this.imageList1.Images.SetKeyName(6, "comp.png");
            this.imageList1.Images.SetKeyName(7, "txt.png");
            this.imageList1.Images.SetKeyName(8, "html.png");
            this.imageList1.Images.SetKeyName(9, "xlsx.png");
            this.imageList1.Images.SetKeyName(10, "other.png");
            this.imageList1.Images.SetKeyName(11, "Picture19.png");
            // 
            // lFile
            // 
            this.lFile.Location = new System.Drawing.Point(0, 44);
            this.lFile.Name = "lFile";
            this.lFile.Size = new System.Drawing.Size(755, 446);
            this.lFile.TabIndex = 0;
            this.lFile.UseCompatibleStateImageBehavior = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::AppCHAT.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(666, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(77, 37);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDecompress
            // 
            this.btnDecompress.BackgroundImage = global::AppCHAT.Properties.Resources.Picture19;
            this.btnDecompress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecompress.Location = new System.Drawing.Point(597, 3);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(48, 39);
            this.btnDecompress.TabIndex = 1;
            this.btnDecompress.UseVisualStyleBackColor = true;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // fileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 490);
            this.Controls.Add(this.btnDecompress);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lFile);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fileExplorer";
            this.Text = "fileExplorer";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.fileExplorer_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private ImageList imageList1;
        private ListView lFile;
        private Button btnRefresh;
        private Button btnDecompress;
    }
}