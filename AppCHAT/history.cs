using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
namespace AppCHAT
{
    public partial class history : Form
    {
        //this app can show 10 buddy 
        List<log> listChatForm = new List<log>();
        int presentChatForm = -1;
        public history()
        {
            InitializeComponent();
            Load();

            //initialize buddy's chat form
            for (int i = 0; i < 9; i++)
            {
                log lg = new log() { TopLevel = false, TopMost = true };
                listChatForm.Add(lg);
                pnlChat.Controls.Add(lg);
            }
        }
        List<Button> buddyList = new List<Button>();
        List<string> listName = new List<string>();
        void Load()
        {
            pnlBuddy.Controls.Clear();

            foreach (data dt in listData.Instance.List)
            {
                if(listName.Exists(x => x == dt.Name)==false)
                    listName.Add(dt.Name);   
            }
            for (int i = 0; i < listName.Count; i++)
            {
                Button buddy = new Button();
                buddy.Location = new System.Drawing.Point(0, i * 50);
                buddy.BackColor = System.Drawing.Color.Transparent;
                buddy.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                buddy.FlatAppearance.BorderSize = 0;
                buddy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
                buddy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
                buddy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                buddy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                buddy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                buddy.Name = i.ToString();
                buddy.Size = new System.Drawing.Size(140, 50);
                buddy.Text = listName[i];
                buddy.UseVisualStyleBackColor = false;
                buddy.Click += (sender, EventArgs) => { buttonNext_Click(sender, EventArgs, int.Parse(buddy.Name), buddy.Text); };


                buddy.ForeColor = Color.White;
               
                pnlBuddy.Controls.Add(buddy);
                buddyList.Add(buddy);
            }
        }
        void buttonNext_Click(object sender, EventArgs e, int index, string name)
        {
            if (presentChatForm != -1)
                listChatForm[presentChatForm].Hide();
            presentChatForm = index;
            listChatForm[presentChatForm].name = name;
            listChatForm[presentChatForm].Show();
        }

        private void history_Load(object sender, EventArgs e)
        {

        }
    }
}

