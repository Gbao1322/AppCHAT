using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCHAT
{
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
            LoadHistory();
        }
        public string name;
        void LoadHistory()
        {
            foreach (data dt in listData.Instance.List)
            {
                if (dt.Name == name)
                    listBox1.Items.Add(dt.Message);
            }
        }


        private void listBox1_VisibleChanged(object sender, EventArgs e)
        {
            LoadHistory(); 
        }
    }
}
