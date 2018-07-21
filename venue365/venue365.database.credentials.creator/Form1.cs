using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using venue365.securityprovider;

namespace venue365.database.credentials.creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            try
            {
                string host = txtHost.Text.Trim();
                string database = txtDatabase.Text.Trim();
                string appKey = txtAppKey.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                string key = KeyBuilder.Build(host, database, appKey);
                SecurityClient.Add(key, string.Format("{0},{1}", username, password));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string appKey = txtAppKey.Text.Trim();

            string key = KeyBuilder.Build(host, database, appKey);

            MessageBox.Show(SecurityClient.Get(key));

        }
    }
}
