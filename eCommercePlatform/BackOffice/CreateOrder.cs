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
    public partial class CreateOrder : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        public CreateOrder()
        {
            InitializeComponent();
            comboBoxUser.DropDownStyle = ComboBoxStyle.DropDownList;
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllUsers";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    comboBoxUser.Items.Add($"{myReader[0]}; {myReader[1]} {myReader[2]} - {myReader[3]}");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                myConnection.Close();
            }
            comboBoxUser.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();

                myCommand.Connection = myConnection;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                myCommand.CommandText = "spCreateOrder";

                SqlParameter _userid = new SqlParameter("@UserId", SqlDbType.Int);
                int slc = comboBoxUser.SelectedItem.ToString().IndexOf(";");
                _userid.Value = Convert.ToInt32(comboBoxUser.SelectedItem.ToString().Substring(0, slc));
                myCommand.Parameters.Add(_userid);

                SqlParameter _date = new SqlParameter("@OrderDate", SqlDbType.Date);
                _date.Value = DateTime.Today;
                myCommand.Parameters.Add(_date);

                SqlParameter _newId = new SqlParameter("@new_OID", SqlDbType.Int);
                _newId.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(_newId);

                int result = myCommand.ExecuteNonQuery();
                MessageBox.Show("Order Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"spCreateOrder: {ex.Message}");
            }
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
