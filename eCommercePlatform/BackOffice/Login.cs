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
    public partial class Login : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = buttonOk;
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
                MainWindow main = new MainWindow(textBoxUserName.Text, true);
                main.ShowDialog();
            } else
            {
                MessageBox.Show("Wrong username or password.");
            }
        }

        private bool ValidUserAndPassword ()
        {
            bool ret = false;
            string usr = textBoxUserName.Text;
            string pw = textBoxPassword.Text;

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"select AdminPassword from [Admin] where AdminLogin = '{usr}'";

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader[0].ToString() == pw)
                        ret = true;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                myConnection.Close();
            }

            return ret;
        }
    }
}
