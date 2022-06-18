﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System;
using System.IO;
using System.Text;
namespace AppCHAT
{
    public partial class sendFile : Form
    {
        const int PORT = 1723;
        public sendFile()
        {
            InitializeComponent();
            
        }

        #region compress
        public static byte[] CompressBytes(byte[] bytes)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var compressionStream = new GZipStream(outputStream, CompressionLevel.Optimal))
                {
                    compressionStream.Write(bytes, 0, bytes.Length);
                }
                return outputStream.ToArray();
            }
        }
        public static byte[] DecompressBytes(byte[] bytes)
        {
            using (var inputStream = new MemoryStream(bytes))
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var compressionStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        compressionStream.CopyTo(outputStream);
                    }
                    return outputStream.ToArray();
                }
            }
        }

        #endregion
        void resetControls()
        {
            tbxIp.Enabled = tbxFile.Enabled = btnSend.Enabled = true;
            btnSend.Text = "Send";
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;
        }

        string filePath;
        bool compress=false;
        private async void button1_Click(object sender, EventArgs e)
        {
            if(cbxCompress.Checked)
            {
                compress = true;
                var bytes = System.IO.File.ReadAllBytes(tbxFile.Text); // MAKE SURE TEMP.txt EXISTS!!!
                bytes = CompressBytes(bytes);
                string fileName = Path.GetFileName(tbxFile.Text);
                filePath= fileName+ ".gzip";
                System.IO.File.WriteAllBytes(filePath, bytes);
            }
            else
                filePath=tbxFile.Text;

            tbxIp.Enabled = tbxFile.Enabled = btnSend.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;

            // Parsing
            btnSend.Text = "Preparing...";
            IPAddress address;
            FileInfo file;
            FileStream fileStream;
            if (!IPAddress.TryParse(tbxIp.Text, out address))
            {
                MessageBox.Show("Error with IP Address");
                resetControls();
                return;
            }
            try
            {
                file = new FileInfo(filePath);
                fileStream = file.OpenRead();
            }
            catch
            {
                MessageBox.Show("Error opening file");
                resetControls();
                return;
            }

            // Connecting
            btnSend.Text = "Connecting...";
            TcpClient client = new TcpClient();
            try
            {
                await client.ConnectAsync(address, PORT);
            }
            catch
            {
                MessageBox.Show("Error connecting to destination");
                resetControls();
                return;
            }
            NetworkStream ns = client.GetStream();

            // Send file info
            btnSend.Text = "Sending file info...";
            { // This syntax sugar is awesome
                byte[] fileName = ASCIIEncoding.ASCII.GetBytes(file.Name);
                byte[] fileNameLength = BitConverter.GetBytes(fileName.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                await ns.WriteAsync(fileLength, 0, fileLength.Length);
                await ns.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                await ns.WriteAsync(fileName, 0, fileName.Length);
            }

            // Get permissions
            btnSend.Text = "Getting permission...";
            {
                byte[] permission = new byte[1];
                await ns.ReadAsync(permission, 0, 1);
                if (permission[0] != 1)
                {
                    MessageBox.Show("Permission denied");
                    resetControls();
                    return;
                }
            }

            // Sending
            btnSend.Text = "Sending...";
            progressBar1.Style = ProgressBarStyle.Continuous;
            int read;
            int totalWritten = 0;
            byte[] buffer = new byte[32 * 1024]; // 32k chunks
            while ((read = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await ns.WriteAsync(buffer, 0, read);
                totalWritten += read;
                progressBar1.Value = (int)((100d * totalWritten) / file.Length);
            }

            fileStream.Dispose();
            client.Close();
            MessageBox.Show("Sending complete!");
            resetControls();

            if (compress)
                DeleteAfterCompress(filePath);
        }

        void DeleteAfterCompress(string filePath)
        {
            //delete temp zip file
            if (File.Exists(Path.Combine("", filePath)))
                File.Delete(Path.Combine("", filePath));
            compress = false;
        }
        private void textBox2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxFile.Text = ofd.FileName;
            }

        }

    }
}
