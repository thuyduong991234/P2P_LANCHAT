using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace P2PDemo
{
    public partial class Form2 : Form
    {
        private Socket socket = null;
        
        
        public Form2(Socket socket)
        {
            this.socket = socket;
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socket != null)
            {
                if (MessageBox.Show("Do you want to cancel ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    socket.Close();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public void SafeClose()
        {
            this.socket = null;
            this.Close();
        }


    }
}
