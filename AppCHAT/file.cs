using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.IO.Compression;
using Ganss.Excel;

namespace AppCHAT
{
    public partial class file : Form
    {
        public file()
        {
            InitializeComponent();
        }

        public string ipTo="null";

        #region send file
        const int PORT = 1723;

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

        void resetControls()
        {
            btnSendFile.Text = "Send File";
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;
        }

        string filePath;
        bool compress = false;
        private async void btnSendFileFile_Click(object sender, EventArgs e)
        {
            if (cbxCompress.Checked)
            {
                compress = true;
                var bytes = System.IO.File.ReadAllBytes(tbxFile.Text); // MAKE SURE TEMP.txt EXISTS!!!
                bytes = CompressBytes(bytes);
                string fileName = Path.GetFileName(tbxFile.Text);
                filePath = fileName + ".gzip";
                System.IO.File.WriteAllBytes(filePath, bytes);
            }
            else
                filePath = tbxFile.Text;

            tbxFile.Enabled = btnSendFile.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;

            // Parsing
            btnSendFile.Text = "Preparing...";
            IPAddress address;
            FileInfo file;
            FileStream fileStream;
            if (!IPAddress.TryParse(ipTo, out address))
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
            btnSendFile.Text = "Connecting...";
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
            btnSendFile.Text = "Sending file info...";
            { // This syntax sugar is awesome
                byte[] fileName = ASCIIEncoding.ASCII.GetBytes(file.Name);
                byte[] fileNameLength = BitConverter.GetBytes(fileName.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                await ns.WriteAsync(fileLength, 0, fileLength.Length);
                await ns.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                await ns.WriteAsync(fileName, 0, fileName.Length);
            }

            // Get permissions
            btnSendFile.Text = "Getting permission...";
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
            btnSendFile.Text = "Sending...";
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

        private void tbxFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string pathS = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Chat App"; // this is the path that you are checking.
            if (Directory.Exists(pathS))
                ofd.InitialDirectory = pathS;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tbxFile.Text = ofd.FileName;
        }

        void DeleteAfterCompress(string filePath)
        {
            //delete temp zip file after sending
            if (File.Exists(Path.Combine("", filePath)))
                File.Delete(Path.Combine("", filePath));
            compress = false;
        }

        #endregion


        #region receive file

        private void resetControls1()
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
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

            string pathS = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Chat App"; // this is the path that you are checking.
            if (Directory.Exists(pathS))
                sfd.InitialDirectory = pathS;
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
            resetControls1();

            //for keep sending and receiving files:
            this.Refresh();
        }

        #endregion

    }
}
