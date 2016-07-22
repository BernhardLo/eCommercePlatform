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
    public partial class CreateProduct : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        public CreateProduct()
        {
            InitializeComponent();
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllCategories";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    comboBoxCategory.Items.Add($"{myReader[0]}; {myReader[1]}");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                myConnection.Close();
            }
            comboBoxCategory.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();

                myCommand.Connection = myConnection;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                myCommand.CommandText = "spCreateProduct";

                SqlParameter _name = new SqlParameter("@Name", SqlDbType.VarChar);
                _name.Value = textBoxName.Text;
                myCommand.Parameters.Add(_name);

                SqlParameter _catid = new SqlParameter("@CatID", SqlDbType.Int);
                int slc = comboBoxCategory.SelectedItem.ToString().IndexOf(";");
                _catid.Value = Convert.ToInt32(comboBoxCategory.SelectedItem.ToString().Substring(0, slc));
                myCommand.Parameters.Add(_catid);

                SqlParameter _desc = new SqlParameter("@Desc", SqlDbType.VarChar);
                _desc.Value = textBox4.Text;
                myCommand.Parameters.Add(_desc);

                SqlParameter _price = new SqlParameter("@Price", SqlDbType.Money);
                _price.Value = textBoxPrice.Text;
                myCommand.Parameters.Add(_price);

                SqlParameter _quantity = new SqlParameter("@Quantity", SqlDbType.Int);
                _quantity.Value = textBoxQuantity.Text;
                myCommand.Parameters.Add(_quantity);

                SqlParameter _isAvailable = new SqlParameter("@IsAvailable", SqlDbType.Bit);
                if (checkBoxIsAvailable.Checked)
                {
                    _isAvailable.Value = "True";
                } else
                {
                    _isAvailable.Value = "False";
                }
                myCommand.Parameters.Add(_isAvailable);

                SqlParameter _newId = new SqlParameter("@new_ProdId", SqlDbType.Int);
                _newId.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(_newId);

                int result = myCommand.ExecuteNonQuery();
                MessageBox.Show(result.ToString());
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();
            }

            MessageBox.Show("Product Created.");
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //@Name varchar(MAX),
        //@CatID int,
        //@Desc varchar(MAX),
        //@Price money,
        //@Quantity int,
        //@IsAvailable bit,
        //@new_ProdId int output
    }
}
