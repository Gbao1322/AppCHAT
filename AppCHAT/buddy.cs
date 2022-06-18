using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace AppCHAT
{
    public partial class buddy : Form
    {
        //this app can show 10 buddy 
        List<chat> listChatForm = new List<chat>();
        List<file> listFileForm = new List<file>();

        int presentForm = -1;
        public buddy()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            //initialize buddy's chat form
            for (int i = 0; i < 9; i++)
            {
                chat ct = new chat() { TopLevel = false, TopMost = true };
                listChatForm.Add(ct);
                pnlChat.Controls.Add(ct);

                file fl = new file() { TopLevel = false, TopMost = true };
                listFileForm.Add(fl);
                pnlFile.Controls.Add(fl);
            }
        }

        #region get my ip
        public string getListeningIP(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties adapterProperties = item.GetIPProperties();
                    if (adapterProperties.GatewayAddresses.FirstOrDefault() != null)
                        foreach (UnicastIPAddressInformation ip in adapterProperties.UnicastAddresses)
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                output = ip.Address.ToString();
                }
            }
            return output;
        }
        public string getIPV4()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet && getListeningIP(NetworkInterfaceType.Ethernet).Length >= 1)
                    return getListeningIP(NetworkInterfaceType.Ethernet);
                else if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && getListeningIP(NetworkInterfaceType.Wireless80211).Length >= 1)
                    return getListeningIP(NetworkInterfaceType.Wireless80211);
            }
            return null;
        }
        #endregion

        #region scan ip
        List<Button> buddyList = new List<Button>();
        List<string> ipAdd = new List<string>();
        List<string> hostName = new List<string>();
        public string Gateway()
        {
            string gw = string.Empty;
            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                    foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                        gw = d.Address.ToString();
            }
            return gw;
        }
        public string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                    return entry.HostName;
            }
            catch (SocketException) { }
            return null;
        }

        public void ping(string gw, string myip)
        {
            string[] root = gw.Split('.');
            int[] a = new int[256];
            for (int i = 0; i < 256; i++)
                a[i] = i;
            foreach (int i in a)
            {
                if (i == int.Parse(gw.Split('.')[3]) || i == int.Parse(myip.Split('.')[3]))
                    continue;
                Thread t = new Thread(() =>
                {
                    bool pingable = false;
                    string ip = root[0] + '.' + root[1] + '.' + root[2] + '.' + i.ToString();

                    Ping pinger = new Ping();
                    try
                    {
                        PingReply reply = pinger.Send(ip);
                        pingable = reply.Status == IPStatus.Success;
                        if (pingable)
                        {
                            ipAdd.Add(ip);
                            //string hostName_ = GetHostName(ip);
                            //if (hostName_ != null)
                            //    hostName.Add(hostName_);
                            //else
                            //    hostName.Add(ip);
                        }
                    }
                    catch (PingException) { }
                });
                t.Start();
            }
        }
        #endregion

        private void btnScan_Click(object sender, EventArgs e)
        {
            pnlBuddy.Controls.Clear();
            ipAdd.Clear();
            hostName.Clear();
            ping(Gateway(), getIPV4());
            Thread.Sleep(5000);

            foreach (string ip in ipAdd)
            {
                string hostName_ = GetHostName(ip);
                if (hostName_ != null)
                    hostName.Add(hostName_);
                else
                    hostName.Add(ip);
            }

            for (int i = 0; i < hostName.Count; i++)
            {
                Button buddy = new Button();
                buddy.Location = new System.Drawing.Point(0, i * 50);
                buddy.BackColor = System.Drawing.Color.Transparent;
                buddy.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                buddy.FlatAppearance.BorderSize = 0;
                buddy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
                buddy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
                buddy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                buddy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                buddy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                buddy.Name = i.ToString();
                buddy.Size = new System.Drawing.Size(140, 50);
                buddy.Text = hostName[i];
                buddy.UseVisualStyleBackColor = false;
                buddy.Click += (sender, EventArgs) => { buttonNext_Click(sender, EventArgs, int.Parse(buddy.Name), hostName[i-1]); };

                buddy.TextAlign = ContentAlignment.MiddleRight;
                buddy.BackgroundImage = imageList4.Images[0];
                buddy.BackgroundImageLayout = ImageLayout.Stretch;

                pnlBuddy.Controls.Add(buddy);
                buddyList.Add(buddy);
            }
        }
        void buttonNext_Click(object sender, EventArgs e, int index, string frname)
        {

            if (presentForm != -1)
            {
                listChatForm[presentForm].Hide();
                listFileForm[presentForm].Hide();
            }
            presentForm = index;
            listChatForm[presentForm].ipTo = ipAdd[index];
            listChatForm[presentForm].frname = frname;
            listFileForm[presentForm].ipTo = ipAdd[index];


            listChatForm[presentForm].Show();
            listFileForm[presentForm].Show();
        }

    }
}
