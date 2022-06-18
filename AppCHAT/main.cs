
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
namespace AppCHAT
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lblName.Text = Environment.UserName;
            lblIP.Text = getIPV4();
        }

        //3 main form
        buddy bd = new buddy() { TopLevel = false, TopMost = true };
        fileExplorer fe = new fileExplorer() {  TopLevel = false, TopMost = true };
        history st = new history() { TopLevel = false, TopMost = true };

        private void main_Load(object sender, EventArgs e)
        {
            this.pnl2.Controls.Add(bd);
            this.pnl2.Controls.Add(fe);
            this.pnl2.Controls.Add(st);
            bd.Show();
        }

        private void btnBuddy_Click(object sender, EventArgs e)
        {
            bd.Show();
            fe.Hide();
            st.Hide();
            btnBuddy.BackColor = Color.DarkRed;
            btnFile.BackColor = System.Drawing.Color.Transparent;
            btnSetting.BackColor = System.Drawing.Color.Transparent;
            btnBuddy.ForeColor = Color.White;
            btnFile.ForeColor = Color.Black;
            btnSetting.ForeColor = Color.Black;
            btnBuddy.BackgroundImage = imageList2.Images[0];
            btnFile.BackgroundImage = imageList2.Images[4];
            btnSetting.BackgroundImage = imageList2.Images[5];
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            bd.Hide();
            fe.Show();
            st.Hide();
            btnBuddy.BackColor = System.Drawing.Color.Transparent;
            btnFile.BackColor = System.Drawing.Color.DarkRed;
            btnSetting.BackColor = System.Drawing.Color.Transparent;
            btnBuddy.ForeColor = Color.Black;
            btnFile.ForeColor = Color.White;
            btnSetting.ForeColor = Color.Black;
            btnBuddy.BackgroundImage = imageList2.Images[3];
            btnFile.BackgroundImage = imageList2.Images[1];
            btnSetting.BackgroundImage = imageList2.Images[5];
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            bd.Hide();
            fe.Hide();
            st.Show();
            btnBuddy.BackColor = System.Drawing.Color.Transparent;
            btnFile.BackColor = System.Drawing.Color.Transparent;
            btnSetting.BackColor = System.Drawing.Color.DarkRed;
            btnBuddy.ForeColor = Color.Black;
            btnFile.ForeColor = Color.Black ;
            btnSetting.ForeColor = Color.White;
            btnBuddy.BackgroundImage = imageList2.Images[3];
            btnFile.BackgroundImage = imageList2.Images[4];
            btnSetting.BackgroundImage = imageList2.Images[2];

        }

        public string getListeningIP(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties adapterProperties = item.GetIPProperties();

                    if (adapterProperties.GatewayAddresses.FirstOrDefault() != null)
                    {
                        foreach (UnicastIPAddressInformation ip in adapterProperties.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                output = ip.Address.ToString();
                            }
                        }
                    }
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

        private void btnBuddy_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}