using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        ClientForm clientForm;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LoginForm(ClientForm clientForm)
        {
            this.clientForm = clientForm;
            logger.Trace("LoginForm loaded");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger.Error($"Client \"{textBox1.Text}\" authenticated ");
            clientForm.login = textBox1.Text;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrEmpty(textBox1.Text);
        }
    }
}
