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
    public partial class EditAdress : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        int userID;
        int addressID;
        public EditAdress(int userID, int addressID)
        {
            InitializeComponent();
            this.userID = userID;
            this.addressID = addressID;
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAddress";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlParameter _uid = new SqlParameter("@addressID", SqlDbType.Int);
                _uid.Value = addressID;
                myCommand.Parameters.Add(_uid);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    textBoxStreet.Text = myReader[2].ToString();
                    textBoxPostalcode.Text = myReader[3].ToString();
                    textBoxCity.Text = myReader[4].ToString();

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
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spUpdateAddress";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                SqlParameter _aid = new SqlParameter("@AID", SqlDbType.Int);
                _aid.Value = addressID;
                myCommand.Parameters.Add(_aid);

                SqlParameter _uid = new SqlParameter("@UserID", SqlDbType.Int);
                _uid.Value = userID;
                myCommand.Parameters.Add(_uid);

                SqlParameter _street = new SqlParameter("@Street", SqlDbType.VarChar);
                _street.Value = textBoxStreet.Text;
                myCommand.Parameters.Add(_street);

                SqlParameter _postalcode = new SqlParameter("@PostalCode", SqlDbType.VarChar);
                _postalcode.Value = textBoxPostalcode.Text;
                myCommand.Parameters.Add(_postalcode);

                SqlParameter _city = new SqlParameter("@City", SqlDbType.VarChar);
                _city.Value = textBoxCity.Text;
                myCommand.Parameters.Add(_city);

                result = myCommand.ExecuteNonQuery();
                MessageBox.Show("Adress Updated");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
