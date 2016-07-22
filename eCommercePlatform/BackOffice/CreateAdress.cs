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
    public partial class CreateAdress : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        int userID;
        public CreateAdress(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spCreateAddress";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                SqlParameter _new_aid = new SqlParameter("@new_AID", SqlDbType.Int);
                _new_aid.Direction = ParameterDirection.Output;
                SqlParameter _userID = new SqlParameter("@UserId", SqlDbType.Int);
                _userID.Value = userID;
                SqlParameter _street = new SqlParameter("@Street", SqlDbType.VarChar);
                _street.Value = textBoxStreet.Text;
                SqlParameter _postalcode = new SqlParameter("@PostalCode", SqlDbType.VarChar);
                _postalcode.Value = textBoxPostalcode.Text;
                SqlParameter _city = new SqlParameter("@City", SqlDbType.VarChar);
                _city.Value = textBoxCity.Text;

                myCommand.Parameters.Add(_new_aid);
                myCommand.Parameters.Add(_userID);
                myCommand.Parameters.Add(_street);
                myCommand.Parameters.Add(_postalcode);
                myCommand.Parameters.Add(_city);

                int result = myCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Adress Created.");
                }

            }
            catch (Exception ex) { MessageBox.Show("spCreateAddress: " + ex.Message); }
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
