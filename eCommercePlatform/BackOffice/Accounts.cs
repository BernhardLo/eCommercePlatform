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
    public partial class Accounts : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        public Accounts()
        {
            InitializeComponent();
            ImportAdmins();
        }

        public void ImportAdmins()
        {
            listBox1.Items.Clear();

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAdmin";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listBox1.Items.Add($"{myReader[0]}; {myReader[1]}");
                }

            }
            catch (Exception ex) { MessageBox.Show("spReadAdmin: " + ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAdmin ca = new CreateAdmin();
            ca.Show();
        }

        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spDeleteAdmin";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();

                    SqlParameter _aid = new SqlParameter("@AdminID", SqlDbType.Int);
                    int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                    _aid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                    myCommand.Parameters.Add(_aid);

                    int result = myCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Admin Deleted.");
                    }

                }
                catch (Exception ex) { MessageBox.Show("spDeleteAdmin: " + ex.Message); }
                finally
                {
                    myConnection.Close();
                }
            } else
            {
                MessageBox.Show("No account selected");
            }

            ImportAdmins();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ImportAdmins();
        }
    }
}
