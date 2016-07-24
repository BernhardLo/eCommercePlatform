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
    public partial class UpdateUser : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        private int UID;
        public UpdateUser(int UID)
        {
            InitializeComponent();
            this.UID = UID;
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadUser";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlParameter _uid = new SqlParameter("@UID", SqlDbType.Int);
                _uid.Value = UID;
                myCommand.Parameters.Add(_uid);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    textBoxFirstName.Text = myReader[1].ToString();
                    textBoxLastName.Text = myReader[2].ToString();
                    textBoxEmail.Text = myReader[3].ToString();
                    textBoxUserName.Text = myReader[4].ToString();
                    textBoxPassword.Text = myReader[5].ToString();

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (!String.IsNullOrWhiteSpace(textBoxFirstName.Text) && !String.IsNullOrWhiteSpace(textBoxLastName.Text) && !String.IsNullOrWhiteSpace(textBoxEmail.Text)
                && !String.IsNullOrWhiteSpace(textBoxUserName.Text) && !String.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spUpdateUser";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();

                    SqlParameter _uid = new SqlParameter("@UID", SqlDbType.Int);
                    _uid.Value = UID;
                    myCommand.Parameters.Add(_uid);

                    SqlParameter _firstname = new SqlParameter("@FirstName", SqlDbType.VarChar);
                    _firstname.Value = textBoxFirstName.Text;
                    myCommand.Parameters.Add(_firstname);

                    SqlParameter _lastname = new SqlParameter("@LastName", SqlDbType.VarChar);
                    _lastname.Value = textBoxLastName.Text;
                    myCommand.Parameters.Add(_lastname);

                    SqlParameter _email = new SqlParameter("@Email", SqlDbType.VarChar);
                    _email.Value = textBoxEmail.Text;
                    myCommand.Parameters.Add(_email);

                    SqlParameter _username = new SqlParameter("@Username", SqlDbType.VarChar);
                    _username.Value = textBoxUserName.Text;
                    myCommand.Parameters.Add(_username);

                    SqlParameter _password = new SqlParameter("@Password", SqlDbType.VarChar);
                    _password.Value = textBoxPassword.Text;
                    myCommand.Parameters.Add(_password);

                    result = myCommand.ExecuteNonQuery();
                    MessageBox.Show("User Updated");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally
                {
                    myConnection.Close();
                }
                this.Hide();
            } else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
