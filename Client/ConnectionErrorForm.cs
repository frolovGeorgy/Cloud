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
    public partial class ConnectionErrorForm : Form
    {
        public ConnectionErrorForm(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
