using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using venue365.securityprovider.Utilities;

namespace venue365.encryptordecryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInputString.Text.Trim()))
                    throw new ArgumentNullException(nameof(txtInputString));
                txtEncodedString.Text = Crypto.Encode(Keys.EncryptionKey, txtInputString.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEncodedString.Text.Trim()))
                    throw new ArgumentNullException(nameof(txtEncodedString));
                txtDecodedString.Text = Crypto.Decode(Keys.EncryptionKey, txtEncodedString.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
