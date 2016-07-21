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
    public partial class MainWindow : Form
    {
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();
        bool masterAdmin = false;

        public MainWindow(string usr, bool isAdmin)
        {
            InitializeComponent();
            DisplayProducts();
            labelUserInfo.Text = $"Logged in as {usr}";
            if (isAdmin)
            {
                labelUserInfo.Text += " (Admin)";
                masterAdmin = true;
            } else
            {
                menuItemManage.Enabled = false;
            }
        }

        private void DisplayProducts ()
        {
            label1.Text = "Categories";
            ImportCategories();
            label2.Text = "Products";
            ImportProducts();
            checkBoxAvailable.Show();
            textBoxQuantity.Show();
            labelQuantity.Show();
            textBoxProductInfo.Show();
            labelProductInfo.Show();

            buttonCreateCategory.Show();
            buttonUpdateCategory.Show();
            buttonDeleteCategory.Show();
            buttonAddProduct.Show();
            buttonUpdateProduct.Show();

            buttonCreateUser.Hide();
            buttonUpdateUser.Hide();
            buttonDeleteUser.Hide();

            buttonSortByValue.Hide();
            buttonSortByUser.Hide();
            buttonSortByNewest.Hide();

            menuItemUsers.Checked = false;
            menuItemProducts.Checked = true;
            menuItemOrders.Checked = false;

            label4.Hide();
            listBox4.Hide();
        }

        private void ImportCategories ()
        {
            listBox1.Items.Clear();

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllCategories";
                myCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader myReader = myCommand.ExecuteReader();
                listBox1.Items.Add("<all>");
                listBox1.SetSelected(0, true);
                while (myReader.Read())
                {
                    listBox1.Items.Add($"{myReader[0]}; {myReader[1]}");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
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
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listBox2.Items.Add($"{myReader[0]}; {myReader[1]} - {myReader[2]} - {myReader[4]}");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                myConnection.Close();
            }

        }

        private void DisplayUsers ()
        {
            label1.Text = "Users";
            ImportUsers();
            label2.Text = "Addresses";
            ImportAddresses();
            checkBoxAvailable.Hide();
            textBoxQuantity.Hide();
            labelQuantity.Hide();
            textBoxProductInfo.Hide();
            labelProductInfo.Hide();

            buttonCreateCategory.Hide();
            buttonUpdateCategory.Hide();
            buttonDeleteCategory.Hide();
            buttonAddProduct.Hide();
            buttonUpdateProduct.Hide();

            buttonCreateUser.Show();
            buttonUpdateUser.Show();
            buttonDeleteUser.Show();

            buttonSortByValue.Hide();
            buttonSortByUser.Hide();
            buttonSortByNewest.Hide();
            menuItemUsers.Checked = true;
            menuItemProducts.Checked = false;
            menuItemOrders.Checked = false;

            label4.Show();
            label4.Text = "Orders";
            listBox4.Show();
        }

        private void ImportUsers ()
        {
            listBox1.Items.Clear();

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllUsers";
                myCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    listBox1.Items.Add($"{myReader[0]}; {myReader[1]} {myReader[2]}; {myReader[4]}");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
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

        private void DisplayOrders ()
        {
            label1.Text = "Order";
            ImportOrders();
            label2.Text = "Contents";
            ImportContents();
            checkBoxAvailable.Hide();
            textBoxQuantity.Hide();
            labelQuantity.Hide();
            textBoxProductInfo.Hide();
            labelProductInfo.Hide();

            buttonCreateCategory.Hide();
            buttonUpdateCategory.Hide();
            buttonDeleteCategory.Hide();
            buttonAddProduct.Hide();
            buttonUpdateProduct.Hide();

            buttonCreateUser.Hide();
            buttonUpdateUser.Hide();
            buttonDeleteUser.Hide();

            buttonSortByValue.Show();
            buttonSortByUser.Show();
            buttonSortByNewest.Show();

            menuItemUsers.Checked = false;
            menuItemProducts.Checked = false;
            menuItemOrders.Checked = true;

            label4.Hide();
            listBox4.Hide();
        }

        private void ImportOrders ()
        {
            listBox1.Items.Clear();

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"spReadAllOrders";
                myCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    listBox1.Items.Add($"Order ID: {myReader[0]} - User ID: {myReader[1]}");

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                myConnection.Close();
            }
        }

        private void ImportContents ()
        {
            listBox2.Items.Clear();


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void menuItemProducts_Click(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        private void menuItemUsers_Click_1(object sender, EventArgs e)
        {
            DisplayUsers();
        }

        private void menuItemOrders_Click_1(object sender, EventArgs e)
        {
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
            //Todo: SQL get Product ID of selected item in listBox2
            //update that product with text from textBoxProductName.Text and textBoxProductInfo.Text

            //Update Quantity & IsAvailable in Storage using textBoxQuantity.Text & checkBoxAvailable

            MessageBox.Show("Product Status Updated", "BackOffice",
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            CreateUser cu = new CreateUser();
            cu.Show();
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {

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
            if (menuItemProducts.Checked)
            {
                listBox2.Items.Clear();
                textBoxProductInfo.Clear();
                listBox2.ClearSelected();

                if (listBox1.SelectedItem.ToString() == "<all>")
                {
                    ImportProducts();
                } else
                {
                    int slc = 0;
                    slc = listBox1.SelectedItem.ToString().IndexOf(";");
                    string currentIndex = listBox1.SelectedItem.ToString().Substring(0, slc);
                }


            } else if (menuItemUsers.Checked)
            {
                listBox2.Items.Clear();

            } else if (menuItemOrders.Checked)
            {
                listBox2.Items.Clear();
            }



            //listboxAddresses.Items.Clear();
            //listboxPhones.Items.Clear();

            //int slc = listboxContacts.SelectedItem.ToString().IndexOf(";");

            //string currentIndex = listboxContacts.SelectedItem.ToString().Substring(0, slc);
        }
    }
}
