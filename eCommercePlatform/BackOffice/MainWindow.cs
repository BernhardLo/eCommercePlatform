using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOffice1
{
    public partial class MainWindow : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        bool masterAdmin = false;

        public MainWindow(string usr, bool isAdmin)
        {
            InitializeComponent();
            menuItemProducts.Checked = true;
            DisplayProducts();
            labelUserInfo.Text = $"Logged in as {usr}";
            if (isAdmin)
            {
                labelUserInfo.Text += " (Admin)";
                masterAdmin = true;
            }
            else
            {
                menuItemManage.Enabled = false;
            }
        }

        private void DisplayProducts()
        {
            label1.Text = "Categories";
            ImportCategories();
            label2.Text = "Products";
            ImportProducts();
            checkBoxAvailable.Show();
            textBoxQuantity.Show();
            textBoxPrice.Show();
            labelQuantity.Show();
            labelPrice.Show();
            textBoxProductInfo.Show();
            labelProductInfo.Show();

            buttonCreateCategory2.Show();
            buttonUpdateCategory2.Show();
            buttonDeleteCategory.Show();
            buttonAddProduct.Show();
            buttonUpdateProduct.Show();

            buttonCreateUser.Hide();
            buttonUpdateUser.Hide();
            buttonDeleteUsers.Hide();
            buttonAddAdress.Hide();
            buttonEditAdress.Hide();
            buttonDeleteAdress.Hide();

            buttonCreateOrder.Hide();
            buttonDeleteOrder.Hide();
            buttonAddItem.Hide();

            label4.Hide();
            listBox4.Hide();
        }

        private void ImportCategories()
        {
            listBox1.Items.Clear();

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllCategories";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                listBox1.Items.Add("<all>");
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    listBox1.Items.Add($"{myReader[0]}; {myReader[1]}");
                }

            }
            catch (Exception ex) { MessageBox.Show("spReadAllCategories: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void ImportProducts()
        {
            listBox2.Items.Clear();

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
                    listBox2.Items.Add($"{myReader[0]}; {myReader[1]} - {myReader[2]} - {myReader[4]}");
                }

            }
            catch (Exception ex) { MessageBox.Show("spReadAllProducts: "+ex.Message); }
            finally
            {
                myConnection.Close();
            }

        }

        private void DisplayUsers()
        {
            label1.Text = "Users";
            ImportUsers();
            label2.Text = "Addresses";
            textBox2.Clear();
            listBox2.Items.Clear();
            checkBoxAvailable.Hide();
            textBoxQuantity.Hide();
            textBoxPrice.Hide();
            labelQuantity.Hide();
            labelPrice.Hide();
            textBoxProductInfo.Hide();
            labelProductInfo.Hide();
            textBox1.Clear();
            textBox2.Clear();

            buttonCreateCategory2.Hide();
            buttonUpdateCategory2.Hide();
            buttonDeleteCategory.Hide();
            buttonAddProduct.Hide();
            buttonUpdateProduct.Hide();

            buttonCreateUser.Show();
            buttonUpdateUser.Show();
            buttonDeleteUsers.Show();
            buttonAddAdress.Show();
            buttonEditAdress.Show();
            buttonDeleteAdress.Show();

            buttonCreateOrder.Hide();
            buttonDeleteOrder.Hide();
            buttonAddItem.Hide();

            label4.Show();
            label4.Text = "Orders";
            listBox4.Show();
        }

        private void ImportUsers()
        {
            listBox1.Items.Clear();

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
                    listBox1.Items.Add($"{myReader[0]}; {myReader[1]} {myReader[2]}; {myReader[4]}");
                }

            }
            catch (Exception ex) { MessageBox.Show("spReadAllUsers: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void ImportAddresses()
        {
            listBox2.Items.Clear();
            listBox4.Items.Clear();
        }

        private void DisplayOrders()
        {
            label1.Text = "Order";
            ImportOrders();
            label2.Text = "Contents";
            ImportContents();
            checkBoxAvailable.Hide();
            textBoxQuantity.Hide();
            textBoxPrice.Hide();
            labelQuantity.Hide();
            labelPrice.Hide();
            textBoxProductInfo.Hide();
            labelProductInfo.Hide();

            buttonCreateCategory2.Hide();
            buttonUpdateCategory2.Hide();
            buttonDeleteCategory.Hide();
            buttonAddProduct.Hide();
            buttonUpdateProduct.Hide();

            buttonCreateUser.Hide();
            buttonUpdateUser.Hide();
            buttonDeleteUsers.Hide();
            buttonAddAdress.Hide();
            buttonEditAdress.Hide();
            buttonDeleteAdress.Hide();

            buttonCreateOrder.Show();
            buttonDeleteOrder.Show();
            buttonAddItem.Show();

            label4.Hide();
            listBox4.Hide();
        }

        private void ImportOrders()
        {
            listBox1.Items.Clear();

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllOrders";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    listBox1.Items.Add($"{myReader[0]}; - User ID: {myReader[1]}");

                }

            }
            catch (Exception ex) { MessageBox.Show("spReadAllOrders: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void ImportContents()
        {
            listBox2.Items.Clear();


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void menuItemProducts_Click(object sender, EventArgs e)
        {
            menuItemProducts.Checked = true;
            menuItemUsers.Checked = false;
            menuItemOrders.Checked = false;
            DisplayProducts();
        }

        private void menuItemUsers_Click_1(object sender, EventArgs e)
        {
            menuItemProducts.Checked = false;
            menuItemUsers.Checked = true;
            menuItemOrders.Checked = false;
            DisplayUsers();
        }

        private void menuItemOrders_Click_1(object sender, EventArgs e)
        {
            menuItemProducts.Checked = false;
            menuItemUsers.Checked = false;
            menuItemOrders.Checked = true;
            DisplayOrders();
        }

        private void menuItemManage_Click(object sender, EventArgs e)
        {
            Accounts acc = new Accounts();
            acc.Show();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            int result = 0;
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spUpdateProduct";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlParameter _pid = new SqlParameter("@ProdID", SqlDbType.Int);
                int slc = listBox2.SelectedItem.ToString().IndexOf(";");
                _pid.Value = Convert.ToInt32(listBox2.SelectedItem.ToString().Substring(0, slc));
                myCommand.Parameters.Add(_pid);
                SqlParameter _name = new SqlParameter("@Name", SqlDbType.VarChar);
                _name.Value = textBox2.Text;
                myCommand.Parameters.Add(_name);
                SqlParameter _desc = new SqlParameter("@Desc", SqlDbType.VarChar);
                _desc.Value = textBoxProductInfo.Text;
                myCommand.Parameters.Add(_desc);
                SqlParameter _price = new SqlParameter("@Price", SqlDbType.Money);
                _price.Value = Convert.ToDecimal(textBoxPrice.Text);
                myCommand.Parameters.Add(_price);
                SqlParameter _quantity = new SqlParameter("@Quantity", SqlDbType.Int);
                _quantity.Value = Convert.ToInt32(textBoxQuantity.Text);
                myCommand.Parameters.Add(_quantity);
                SqlParameter _isAvailable = new SqlParameter("@IsAvailable", SqlDbType.Bit);
                if (checkBoxAvailable.Checked)
                    _isAvailable.Value = true;
                else
                    _isAvailable.Value = false;
                myCommand.Parameters.Add(_isAvailable);
                result = myCommand.ExecuteNonQuery();
                MessageBox.Show("Product Status Updated");
            }
            catch (Exception ex) { MessageBox.Show("spUpdateProduct: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }

            ImportProducts();
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            CreateUser cu = new CreateUser();
            cu.Show();
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                int uid = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                UpdateUser uu = new UpdateUser(uid);
                uu.Show();
            } else
            {
                MessageBox.Show("No user is selected.");
            }
        }

        private void buttonDeleteUsers_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spDeleteUser";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                SqlParameter _uid = new SqlParameter("@UserId", SqlDbType.Int);
                int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                _uid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                myCommand.Parameters.Add(_uid);

                int result = myCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("User Deleted.");
                }

            }
            catch (Exception ex) { MessageBox.Show("spDeleteUser: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void buttonCreateCategory_Click_1(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spCreateCategory";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                SqlParameter _new_cid = new SqlParameter("@new_CatId", SqlDbType.Int);
                _new_cid.Direction = ParameterDirection.Output;
                SqlParameter _title = new SqlParameter("@Title", SqlDbType.VarChar);
                _title.Value = textBox1.Text;
                myCommand.Parameters.Add(_new_cid);
                myCommand.Parameters.Add(_title);

                int result = myCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Category Created.");
                }

            }
            catch (Exception ex) { MessageBox.Show("spCreateCategory: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void textBoxProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxProductInfo.Clear();
            textBoxQuantity.Clear();
            textBoxPrice.Clear();
            textBox2.Clear();
            checkBoxAvailable.Checked = false;

            if (menuItemProducts.Checked && listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Clear();
                textBoxProductInfo.Clear();
                listBox2.ClearSelected();

                if (listBox1.SelectedItem.ToString() == "<all>")
                {
                    ImportProducts();
                    buttonCreateCategory2.Enabled = false;
                    buttonUpdateCategory2.Enabled = false;
                    buttonDeleteCategory.Enabled = false;

                }
                else
                {
                    int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                    int currentIndex = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                    ImportProductsFromCategory(currentIndex);
                    buttonCreateCategory2.Enabled = true;
                    buttonUpdateCategory2.Enabled = true;
                    buttonDeleteCategory.Enabled = true;
                    textBox1.Text = listBox1.SelectedItem.ToString().Substring(slc + 2);
                }


            }
            else if (menuItemUsers.Checked && listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Clear();
                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spReadAllAddressesFromUser";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();
                    SqlParameter _uid = new SqlParameter("@UID", SqlDbType.Int);
                    int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                    _uid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                    myCommand.Parameters.Add(_uid);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        listBox2.Items.Add($"{myReader[0]}; {myReader[2]} - {myReader[3]} - {myReader[4]}");
                    }

                }
                catch (Exception ex) { MessageBox.Show("spReadAllAddressesFromUser: " +ex.Message); }
                finally
                {
                    myConnection.Close();
                }

                listBox4.Items.Clear();
                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spReadAllOrdersFromUser";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();
                    SqlParameter _uid = new SqlParameter("@UID", SqlDbType.Int);
                    int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                    _uid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                    myCommand.Parameters.Add(_uid);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        listBox4.Items.Add($"{myReader[0]}; {myReader[2]}");
                    }

                }
                catch (Exception ex) { MessageBox.Show("spReadAllAddressesFromUser: " + ex.Message); }
                finally
                {
                    myConnection.Close();
                }

            }
            else if (menuItemOrders.Checked && listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Clear();
                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spReadAllItemsFromOrder";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();
                    SqlParameter _uid = new SqlParameter("@OID", SqlDbType.Int);
                    int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                    _uid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                    myCommand.Parameters.Add(_uid);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        listBox2.Items.Add($"Product Id: {myReader[0]}; Quantity: {myReader[2]}");
                    }

                }
                catch (Exception ex) { MessageBox.Show("spReadAllItemsFromOrder: " + ex.Message); }
                finally
                {
                    myConnection.Close();
                }
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuItemProducts.Checked)
            {
                textBoxProductInfo.Clear();
                textBoxQuantity.Clear();
                textBoxPrice.Clear();
                checkBoxAvailable.Checked = false;

                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spReadProductDescription";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();
                    SqlParameter _pid = new SqlParameter("@PID", SqlDbType.Int);
                    int slc = listBox2.SelectedItem.ToString().IndexOf(";");
                    _pid.Value = Convert.ToInt32(listBox2.SelectedItem.ToString().Substring(0, slc));
                    myCommand.Parameters.Add(_pid);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        textBoxProductInfo.Text = myReader[0].ToString() ;
                        textBoxPrice.Text = myReader[1].ToString();
                        textBox2.Text = myReader[2].ToString();
                    }

                }
                catch (Exception ex) { MessageBox.Show("spReadProductDescription: " +ex.Message); }
                finally
                {
                    myConnection.Close();
                }

                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spReadProductStorage";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();
                    SqlParameter _pid = new SqlParameter("@PID", SqlDbType.Int);
                    int slc = listBox2.SelectedItem.ToString().IndexOf(";");
                    _pid.Value = Convert.ToInt32(listBox2.SelectedItem.ToString().Substring(0, slc));
                    myCommand.Parameters.Add(_pid);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        textBoxQuantity.Text = myReader[0].ToString();
                        if (myReader[1].ToString() == "True")
                            checkBoxAvailable.Checked = true;
                    }

                }
                catch (Exception ex) { MessageBox.Show("spReadProductStorage: " +ex.Message); }
                finally
                {
                    myConnection.Close();
                }

            } else if (menuItemUsers.Checked)
            {

            } else if (menuItemOrders.Checked)
            {

            }
        }

        private void ImportProductsFromCategory(int currentIndex)
        {
            listBox2.Items.Clear();

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllProductsFromCategory";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                SqlParameter _cid = new SqlParameter("@CID", SqlDbType.Int);
                int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                _cid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                myCommand.Parameters.Add(_cid);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listBox2.Items.Add($"{myReader[0]}; {myReader[1]} - {myReader[2]} - {myReader[4]}");
                }

            }
            catch (Exception ex) { MessageBox.Show("spReadAllProductsFromCategory: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            CreateProduct cproduct = new CreateProduct();
            cproduct.Show();
        }

        private void buttonCreateCategory2_Click_1(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spCreateCategory";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                SqlParameter _new_cid = new SqlParameter("@new_CatId", SqlDbType.Int);
                _new_cid.Direction = ParameterDirection.Output;
                SqlParameter _title = new SqlParameter("@Title", SqlDbType.VarChar);
                _title.Value = textBox1.Text;
                myCommand.Parameters.Add(_new_cid);
                myCommand.Parameters.Add(_title);

                int result = myCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Category Created.");
                }

            }
            catch (Exception ex) { MessageBox.Show("spCreateCategory: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void buttonUpdateCategory2_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spUpdateCategory";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                SqlParameter _cid = new SqlParameter("@CatId", SqlDbType.Int);
                int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                _cid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                SqlParameter _title = new SqlParameter("@Title", SqlDbType.VarChar);
                _title.Value = textBox1.Text;
                myCommand.Parameters.Add(_cid);
                myCommand.Parameters.Add(_title);

                int result = myCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Category Updated.");
                }

            }
            catch (Exception ex) { MessageBox.Show("spUpdateCategory: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }

            ImportCategories();
        }

        private void buttonDeleteCategory_Click_1(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spDeleteCategory";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                SqlParameter _cid = new SqlParameter("@CatId", SqlDbType.Int);
                int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                _cid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                myCommand.Parameters.Add(_cid);

                int result = myCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Category Deleted.");
                }

            }
            catch (Exception ex) { MessageBox.Show("spDeleteCategory: " +ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void buttonAddAdress_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                int userID = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                CreateAdress ca = new CreateAdress(userID);
                ca.Show();
            } else
            {
                MessageBox.Show("No user selected.");
            }

        }

        private void buttonEditAdress_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                int userID = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                int slc2 = listBox2.SelectedItem.ToString().IndexOf(";");
                int addressID = Convert.ToInt32(listBox2.SelectedItem.ToString().Substring(0, slc));
                EditAdress ea = new EditAdress(userID, addressID);
                ea.Show();
            }
            else
            {
                MessageBox.Show("No adress selected.");
            }
        }

        private void buttonDeleteAdress_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spDeleteAddress";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();

                    SqlParameter _cid = new SqlParameter("@AdrId", SqlDbType.Int);
                    int slc = listBox2.SelectedItem.ToString().IndexOf(";");
                    _cid.Value = Convert.ToInt32(listBox2.SelectedItem.ToString().Substring(0, slc));
                    myCommand.Parameters.Add(_cid);

                    int result = myCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Adress Deleted.");
                    }

                }
                catch (Exception ex) { MessageBox.Show("spDeleteAddress: " + ex.Message); }
                finally
                {
                    myConnection.Close();
                }
            } else
            {
                MessageBox.Show("No adress selected.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateOrder co = new CreateOrder();
            co.Show();
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                try
                {
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = $"spDeleteOrder";
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Clear();

                    SqlParameter _oid = new SqlParameter("@OrderId", SqlDbType.Int);
                    int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                    _oid.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                    myCommand.Parameters.Add(_oid);

                    int result = myCommand.ExecuteNonQuery();
                    if (result > 1)
                    {
                        MessageBox.Show("Order Deleted.");
                    }

                }
                catch (Exception ex) { MessageBox.Show("spDeleteOrder: " + ex.Message); }
                finally
                {
                    myConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("No order selected.");
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int slc = listBox1.SelectedItem.ToString().IndexOf(";");
                int orderId = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(0, slc));
                AddItem ai = new AddItem(orderId);
                ai.Show();
            }
        }
    }
}
