using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeerToPeerChat
{
    public partial class LoginForm : Form
    {
        string userName = "";
        public string UserName
        {
            get
            {
                return userName;
            }
        }


        public LoginForm()
        {
            InitializeComponent();
           // this.FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            userName = txtname.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Đặt lại tên!");
                return;
            }
            this.FormClosing -= LoginForm_FormClosing;
            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userName = "";
        }
    }
}
