
using System.Diagnostics;
using System.IO.Compression;

namespace AppCHAT
{
    public partial class fileExplorer : Form
    {
        public fileExplorer()
        {
            InitializeComponent();
             fileAttr = File.GetAttributes(filePath + @"\" + currentlySelectedItemName);
            LoadFiles();
        }

        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\Chat App";
        private bool isFile = false;
        private string currentlySelectedItemName = "";
        FileAttributes fileAttr;

        void LoadFiles()
        {
            lFile.Items.Clear();
            //======================================================================================
            lFile.TabIndex = 0;
            lFile.UseCompatibleStateImageBehavior = false;
            lFile.ItemSelectionChanged += LFile_ItemSelectionChanged;
            lFile.MouseDoubleClick += LFile_MouseDoubleClick;
            lFile.LargeImageList = this.imageList1;
            lFile.SmallImageList = this.imageList1;
            //======================================================================================

            DirectoryInfo fileList;
            string tempFilePath = "";
            try
            {

                //fileAttr = File.GetAttributes(filePath + @"\" + currentlySelectedItemName);
                if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    fileList = new DirectoryInfo(filePath);
                    FileInfo[] files = fileList.GetFiles(); // GET ALL THE FILES
                    DirectoryInfo[] dirs = fileList.GetDirectories(); // GET ALL THE DIRS
                    string fileExtension = "";
                    lFile.Items.Clear();

                    for (int i = 0; i < files.Length; i++)
                    {
                        fileExtension = files[i].Extension.ToUpper();
                        switch (fileExtension)
                        {
                            case ".MP3":
                            case ".MP2":
                                lFile.Items.Add(files[i].Name, 0);
                                break;
                            case ".EXE":
                            case ".COM":
                                lFile.Items.Add(files[i].Name, 1);
                                break;
                            case ".MP4":
                            case ".AVI":
                            case ".MKV":
                                lFile.Items.Add(files[i].Name, 2);
                                break;
                            case ".PDF":
                                lFile.Items.Add(files[i].Name, 3);
                                break;
                            case ".DOC":
                            case ".DOCX":
                                lFile.Items.Add(files[i].Name, 4);
                                break;
                            case ".PNG":
                            case ".JPG":
                            case ".JPEG":
                                lFile.Items.Add(files[i].Name, 5);
                                break;
                            case ".ZIP":
                            case ".RAR":
                            case ".GZIP":
                                lFile.Items.Add(files[i].Name, 6);
                                break;
                            case ".TXT":
                                lFile.Items.Add(files[i].Name, 7);
                                break;
                            case ".HTML":
                                lFile.Items.Add(files[i].Name, 8);
                                break;
                            case ".XLSX":
                                lFile.Items.Add(files[i].Name, 9);
                                break;
                            default:
                                lFile.Items.Add(files[i].Name, 10);
                                break;
                        }
                    }
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        lFile.Items.Add(dirs[i].Name, 10);
                    }
                }

            }
            catch(Exception ex) { }
            isFile = false;
        }
        private void LFile_ItemSelectionChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
        {
            currentlySelectedItemName = e.Item.Text;

            //fileAttr = File.GetAttributes(filePath + @"\" + currentlySelectedItemName);
            //if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
            //{
            //    isFile = false;
            //}
            //else
            //{
            //    isFile = true;
            //}
        }

        private void LFile_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            string tempFilePath = "";
            tempFilePath = filePath + @"\" + currentlySelectedItemName;
            FileInfo fileDetails = new FileInfo(tempFilePath);
            fileAttr = File.GetAttributes(tempFilePath);
            Process.Start(new ProcessStartInfo { FileName = tempFilePath, UseShellExecute = true });
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
        private void btnDecompress_Click(object sender, EventArgs e)
        {
                string dcpsFile = filePath + @"\" + currentlySelectedItemName;
            if(dcpsFile==string.Empty)
                MessageBox.Show("Please Choose any File!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            try
            {
                var bytes_ = System.IO.File.ReadAllBytes(dcpsFile);
                bytes_ = DecompressBytes(bytes_);
                System.IO.File.WriteAllBytes(dcpsFile.Remove(dcpsFile.Length - 5), bytes_);
                MessageBox.Show("Decompress successful!\nPlease click the refresh button.");
            }
            catch (Exception ex) { 
                MessageBox.Show("Decompress unsuccessful!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void fileExplorer_VisibleChanged(object sender, EventArgs e)
        {
            LoadFiles();

        }
    }
}