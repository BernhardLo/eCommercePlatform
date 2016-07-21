using SQLHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOffice1
{
    public partial class CreateUser : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool allFieldsValid()
        {
            bool ret = true;

            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                ret = false;
            }

            return ret;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            if (allFieldsValid() && SQL.CreateUser(
                textBoxFirstName.Text,
                textBoxLastName.Text,
                textBoxEmail.Text,
                textBoxUserName.Text,
                textBoxPassword.Text,
                textBoxStreet.Text,
                textBoxPostalcode.Text,
                textBoxFirstName.Text
                )
                == 1)
            {
                MessageBox.Show("User Created.");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }
    }
}

