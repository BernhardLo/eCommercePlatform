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
        static string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=Orders;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection myConnection = new SqlConnection(conStr);
        static SqlCommand myCommand = new SqlCommand();

        public MainWindow(string usr, bool isAdmin)
        {
            InitializeComponent();
            DisplayProducts();
            labelUserInfo.Text = $"Logged in as {usr}";
            if (isAdmin)
                labelUserInfo.Text += " (Admin)";
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
            //Todo: SQL Get all category names
            //and add to listBox1
        }

        private void ImportProducts()
        {
            //Todo: SQL Get all product names
            //and add to listBox2
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
            //Todo: SQL get all usernames and
            //add to listBox1
        }

        private void ImportAddresses()
        {
            //Todo: SQL get all addresses
            //registered to the selected user
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
            //Todo: SQL get all orders and
            //add to listBox1
        }

        private void ImportContents ()
        {
            //Todo: SQL get all orderitems
            //for the selected order
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
    }
}
