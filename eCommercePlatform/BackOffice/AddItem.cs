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
    public partial class AddItem : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        int OrderId;
        public AddItem(int OrderId)
        {
            InitializeComponent();
            this.OrderId = OrderId;
            comboBoxProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllProducts";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    comboBoxProducts.Items.Add($"{myReader[0]}; {myReader[1]} - {myReader[4]}:-");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                myConnection.Close();
            }
            comboBoxProducts.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();

                myCommand.Connection = myConnection;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                myCommand.CommandText = "spCreateOrderItem";

                SqlParameter _productname = new SqlParameter("@ProductName", SqlDbType.Int);
                int slc = comboBoxProducts.SelectedItem.ToString().IndexOf(";");
                _productname.Value = Convert.ToInt32(comboBoxProducts.SelectedItem.ToString().Substring(0, slc));
                myCommand.Parameters.Add(_productname);

                SqlParameter _orderid = new SqlParameter("@OrderId", SqlDbType.Int);
                _orderid.Value = OrderId;
                myCommand.Parameters.Add(_orderid);

                SqlParameter _quantity = new SqlParameter("@Quantity", SqlDbType.Int);
                _quantity.Value = Convert.ToInt32(textBoxQuantity.Text);
                myCommand.Parameters.Add(_quantity);

                int result = myCommand.ExecuteNonQuery();
                MessageBox.Show("Order Item Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"spCreateOrderItem: {ex.Message}");
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
