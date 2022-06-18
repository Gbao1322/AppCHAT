using System;
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
    public partial class receiveFile : Form
    {
        const int PORT = 1723;
        public receiveFile()
        {
            InitializeComponent();
        }
        private void resetControls()
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            textBox1.Text = "Waiting for connection...";
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
        protected override async void OnShown(EventArgs e)
        {
            // Listen
            TcpListener listener = TcpListener.Create(PORT);
            listener.Start();
            textBox1.Text = "Waiting for connection...";
            TcpClient client = await listener.AcceptTcpClientAsync();
            NetworkStream ns = client.GetStream();

            // Get file info
            long fileLength;
            string fileName;
            {
                byte[] fileNameBytes;
                byte[] fileNameLengthBytes = new byte[4]; //int32
                byte[] fileLengthBytes = new byte[8]; //int64

                await ns.ReadAsync(fileLengthBytes, 0, 8); // int64
                await ns.ReadAsync(fileNameLengthBytes, 0, 4); // int32
                fileNameBytes = new byte[BitConverter.ToInt32(fileNameLengthBytes, 0)];
                await ns.ReadAsync(fileNameBytes, 0, fileNameBytes.Length);

                fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
                fileName = ASCIIEncoding.ASCII.GetString(fileNameBytes);
            }

            // Get permission
            if (MessageBox.Show(String.Format("Requesting permission to receive file:\r\n\r\n{0}\r\n{1} bytes long", fileName, fileLength), "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            // Set save location
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Path.GetFullPath(@"\files");
            sfd.CreatePrompt = false;
            sfd.OverwritePrompt = true;
            sfd.FileName = fileName;
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                ns.WriteByte(0); // Permission denied
                return;
            }
            ns.WriteByte(1); // Permission grantedd
            FileStream fileStream = File.Open(sfd.FileName, FileMode.Create);

            // Receive
            textBox1.Text = "Receiving...";
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Value = 0;
            int read;
            int totalRead = 0;
            byte[] buffer = new byte[32 * 1024]; // 32k chunks
            while ((read = await ns.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, read);
                totalRead += read;
                progressBar1.Value = (int)((100d * totalRead) / fileLength);
            }

            fileStream.Dispose();
            client.Close();

            //decompress if needed
            string[] fname = fileName.Split('.');
            if (fname[fname.Length - 1] == "gzip")
            {
                DialogResult result = MessageBox.Show("File successfully received.\nBut this file has been compressed.\nDo you want to decompress it? ", "Successful", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    var bytes_ = System.IO.File.ReadAllBytes(sfd.FileName);
                    bytes_ = DecompressBytes(bytes_);
                    System.IO.File.WriteAllBytes(sfd.FileName.Remove(sfd.FileName.Length - 5), bytes_);
                }
                MessageBox.Show("Decompress successful!");
            }
            //

            else
                MessageBox.Show("File successfully received");
            resetControls();
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
