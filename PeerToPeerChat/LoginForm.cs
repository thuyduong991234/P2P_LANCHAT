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
            StartPosition = FormStartPosition.CenterScreen;
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
            else if (txtname.Text == "Enter username ...")
            {
                MessageBox.Show("Bạn chưa đặt tên!");
                return;
            }
            this.FormClosing -= LoginForm_FormClosing;
            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userName = "";
        }

        private void txtname_MouseEnter(object sender, EventArgs e)
        {
            if (txtname.Text == "Enter username ...")
                txtname.ResetText();
        }
        // move form
        protected override void OnLoad(EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
            {
                this.MouseDown += new MouseEventHandler(LoginForm_MouseDown);
                this.MouseMove += new MouseEventHandler(LoginForm_MouseMove);
                this.MouseUp += new MouseEventHandler(LoginForm_MouseUp);
            }

            base.OnLoad(e);
        }
        public Point downPoint = Point.Empty;
        void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = new Point(e.X, e.Y);
        }

        void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint == Point.Empty)
            {
                return;
            }
            Point location = new Point(
                this.Left + e.X - downPoint.X,
                this.Top + e.Y - downPoint.Y);
            this.Location = location;
        }

        void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = Point.Empty;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblname_Click(object sender, EventArgs e)
        {

        }
    }
}
