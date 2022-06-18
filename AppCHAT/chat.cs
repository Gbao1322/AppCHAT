using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace AppCHAT
{
    public partial class chat : Form
    {

        Socket sck;
        string myname;
        public bool start = false;
        public string ipTo="null";
        public string frname;
        EndPoint eplocal, epremote;
        public chat()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        void SaveLog(string totalMsg)
        {
            data dt = new data();
            dt.Name = frname;
            char[] charsToTrim = {'\0'};
            dt.Message = totalMsg.Trim(charsToTrim);
            listData.Instance.List.Add(dt);
        }

        #region chat

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
        
        private void closeall(IAsyncResult result)
        {
            sck.EndReceiveFrom(result, ref epremote);
            sck.Close();
        }

        private void MessageCallBack(IAsyncResult aresult)
        {

            try
            {
                int size = sck.EndReceiveFrom(aresult, ref epremote);
                if (size > 0)
                {

                    byte[] receiveddata = new byte[1464];
                    receiveddata = (byte[])aresult.AsyncState;
                    ASCIIEncoding eencoding = new ASCIIEncoding();
                    string receivedmessage = eencoding.GetString(receiveddata);
                    listBox1.Items.Add(receivedmessage);
                    SaveLog(receivedmessage);

                }
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epremote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                string wholemessage = "(" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ") - " + myname + " - " + tbxMsg.Text;
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(wholemessage);
                sck.Send(msg);

                string mymessage = "(" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ") - " + "You - " + tbxMsg.Text;
                listBox1.Items.Add(mymessage);
                SaveLog(mymessage);
                tbxMsg.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Connect()
        {
            try
            {
                myname = Environment.UserName;
                eplocal = new IPEndPoint(IPAddress.Parse(getIPV4()), Convert.ToInt32(55555));
                sck.Bind(eplocal);
                epremote = new IPEndPoint(IPAddress.Parse(ipTo), Convert.ToInt32(55555));
                sck.Connect(epremote);
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epremote, new AsyncCallback(MessageCallBack), buffer);

                listBox1.Items.Add("------------------------------------------------------------------------------------");
                listBox1.Items.Add(" Listening on " + ipTo + "::55555 ");
                listBox1.Items.Add("------------------------------------------------------------------------------------");
                listBox1.Items.Add("");
                start = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void chat_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(ipTo);
            Connect();

        }

        public void Disconnect()
        {
            try
            {
                AsyncCallback b = new AsyncCallback(closeall);
                start = false;
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

    }
}
