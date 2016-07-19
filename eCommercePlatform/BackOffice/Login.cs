using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOffice1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click1(object sender, EventArgs e)
        {
            if (ValidUserAndPassword())
            {
                this.Hide();
                MainWindow main = new MainWindow();
                main.ShowDialog();
            }
        }

        private static bool ValidUserAndPassword ()
        {
            bool ret = true;

            return ret;
        }
    }
}
