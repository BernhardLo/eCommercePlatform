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
    public partial class CreateAdmin : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        public CreateAdmin()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spCreateAdmin";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                SqlParameter _new_aid = new SqlParameter("@new_AID", SqlDbType.Int);
                _new_aid.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(_new_aid);

                SqlParameter _adminlogin = new SqlParameter("@AdminLogin", SqlDbType.VarChar);
                _adminlogin.Value = textBox1.Text;
                myCommand.Parameters.Add(_adminlogin);

                SqlParameter _adminpassword = new SqlParameter("@AdminPassword", SqlDbType.VarChar);
                _adminpassword.Value = textBox2.Text;
                myCommand.Parameters.Add(_adminpassword);


                int result = myCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Admin Created.");
                }

            }
            catch (Exception ex) { MessageBox.Show("spCreateAdmin: " + ex.Message); }
            finally
            {
                myConnection.Close();
            }
            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
