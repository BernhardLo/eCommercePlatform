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

        private bool allFieldsValid ()
        {
            bool ret = true;

            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {

            }



            return ret;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (allFieldsValid())
            {

                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spCreateUser";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = textBoxFirstName.Text;
                    myCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = textBoxLastName.Text;
                    myCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = textBoxEmail.Text;
                    myCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBoxUserName.Text;
                    myCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = textBoxPassword.Text;
                    myCommand.Parameters.Add("@Street", SqlDbType.VarChar).Value = textBoxStreet.Text;
                    myCommand.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = textBoxPostalcode.Text;
                    myCommand.Parameters.Add("@City", SqlDbType.VarChar).Value = textBoxFirstName.Text;
                    myCommand.Parameters.Add("@new_UID", SqlDbType.Int).Direction = ParameterDirection.Output;


                    myCommand.ExecuteNonQuery();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally
                {
                    myConnection.Close();
                }
                this.Hide();
            }
        }
    }
}
