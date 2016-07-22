namespace BackOffice1
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemMenu = new System.Windows.Forms.MenuItem();
            this.menuItemProducts = new System.Windows.Forms.MenuItem();
            this.menuItemUsers = new System.Windows.Forms.MenuItem();
            this.menuItemOrders = new System.Windows.Forms.MenuItem();
            this.menuItemAccount = new System.Windows.Forms.MenuItem();
            this.menuItemLogout = new System.Windows.Forms.MenuItem();
            this.menuItemManage = new System.Windows.Forms.MenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.checkBoxAvailable = new System.Windows.Forms.CheckBox();
            this.textBoxProductInfo = new System.Windows.Forms.TextBox();
            this.labelProductInfo = new System.Windows.Forms.Label();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUpdateProduct = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonUpdateUser = new System.Windows.Forms.Button();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.buttonSortByValue = new System.Windows.Forms.Button();
            this.buttonSortByNewest = new System.Windows.Forms.Button();
            this.buttonSortByUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.buttonUpdateCategory2 = new System.Windows.Forms.Button();
            this.buttonCreateCategory2 = new System.Windows.Forms.Button();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.buttonDeleteUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemMenu,
            this.menuItemAccount});
            // 
            // menuItemMenu
            // 
            this.menuItemMenu.Index = 0;
            this.menuItemMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemProducts,
            this.menuItemUsers,
            this.menuItemOrders});
            this.menuItemMenu.Text = "Menu";
            // 
            // menuItemProducts
            // 
            this.menuItemProducts.Index = 0;
            this.menuItemProducts.Text = "Products";
            this.menuItemProducts.Click += new System.EventHandler(this.menuItemProducts_Click);
            // 
            // menuItemUsers
            // 
            this.menuItemUsers.Index = 1;
            this.menuItemUsers.Text = "Users";
            this.menuItemUsers.Click += new System.EventHandler(this.menuItemUsers_Click_1);
            // 
            // menuItemOrders
            // 
            this.menuItemOrders.Index = 2;
            this.menuItemOrders.Text = "Orders";
            this.menuItemOrders.Click += new System.EventHandler(this.menuItemOrders_Click_1);
            // 
            // menuItemAccount
            // 
            this.menuItemAccount.Index = 1;
            this.menuItemAccount.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemLogout,
            this.menuItemManage});
            this.menuItemAccount.Text = "Account";
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Index = 0;
            this.menuItemLogout.Text = "Log out";
            this.menuItemLogout.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItemManage
            // 
            this.menuItemManage.Index = 1;
            this.menuItemManage.Text = "Manage accounts";
            this.menuItemManage.Click += new System.EventHandler(this.menuItemManage_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(33, 60);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(248, 316);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(308, 60);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(248, 316);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(582, 314);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantity.TabIndex = 6;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(582, 295);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(46, 13);
            this.labelQuantity.TabIndex = 7;
            this.labelQuantity.Text = "Quantity";
            // 
            // checkBoxAvailable
            // 
            this.checkBoxAvailable.AutoSize = true;
            this.checkBoxAvailable.Location = new System.Drawing.Point(582, 340);
            this.checkBoxAvailable.Name = "checkBoxAvailable";
            this.checkBoxAvailable.Size = new System.Drawing.Size(69, 17);
            this.checkBoxAvailable.TabIndex = 8;
            this.checkBoxAvailable.Text = "Available";
            this.checkBoxAvailable.UseVisualStyleBackColor = true;
            // 
            // textBoxProductInfo
            // 
            this.textBoxProductInfo.Location = new System.Drawing.Point(585, 60);
            this.textBoxProductInfo.Multiline = true;
            this.textBoxProductInfo.Name = "textBoxProductInfo";
            this.textBoxProductInfo.Size = new System.Drawing.Size(203, 178);
            this.textBoxProductInfo.TabIndex = 9;
            // 
            // labelProductInfo
            // 
            this.labelProductInfo.AutoSize = true;
            this.labelProductInfo.Location = new System.Drawing.Point(585, 40);
            this.labelProductInfo.Name = "labelProductInfo";
            this.labelProductInfo.Size = new System.Drawing.Size(59, 13);
            this.labelProductInfo.TabIndex = 10;
            this.labelProductInfo.Text = "Information";
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Location = new System.Drawing.Point(33, 470);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(117, 23);
            this.buttonDeleteCategory.TabIndex = 13;
            this.buttonDeleteCategory.Text = "Delete Category";
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 383);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 15;
            // 
            // buttonUpdateProduct
            // 
            this.buttonUpdateProduct.Location = new System.Drawing.Point(308, 441);
            this.buttonUpdateProduct.Name = "buttonUpdateProduct";
            this.buttonUpdateProduct.Size = new System.Drawing.Size(117, 23);
            this.buttonUpdateProduct.TabIndex = 17;
            this.buttonUpdateProduct.Text = "Update Product";
            this.buttonUpdateProduct.UseVisualStyleBackColor = true;
            this.buttonUpdateProduct.Click += new System.EventHandler(this.buttonUpdateProduct_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(308, 412);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(117, 23);
            this.buttonAddProduct.TabIndex = 16;
            this.buttonAddProduct.Text = "Add Product";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(308, 383);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(248, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.TextChanged += new System.EventHandler(this.textBoxProductName_TextChanged);
            // 
            // buttonUpdateUser
            // 
            this.buttonUpdateUser.Location = new System.Drawing.Point(33, 441);
            this.buttonUpdateUser.Name = "buttonUpdateUser";
            this.buttonUpdateUser.Size = new System.Drawing.Size(117, 23);
            this.buttonUpdateUser.TabIndex = 20;
            this.buttonUpdateUser.Text = "Update User";
            this.buttonUpdateUser.UseVisualStyleBackColor = true;
            this.buttonUpdateUser.Click += new System.EventHandler(this.buttonUpdateUser_Click);
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Location = new System.Drawing.Point(33, 409);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(117, 23);
            this.buttonCreateUser.TabIndex = 23;
            this.buttonCreateUser.Text = "Create User";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.buttonCreateUser_Click);
            // 
            // buttonSortByValue
            // 
            this.buttonSortByValue.Location = new System.Drawing.Point(34, 409);
            this.buttonSortByValue.Name = "buttonSortByValue";
            this.buttonSortByValue.Size = new System.Drawing.Size(117, 23);
            this.buttonSortByValue.TabIndex = 26;
            this.buttonSortByValue.Text = "Sort By Value";
            this.buttonSortByValue.UseVisualStyleBackColor = true;
            // 
            // buttonSortByNewest
            // 
            this.buttonSortByNewest.Location = new System.Drawing.Point(31, 470);
            this.buttonSortByNewest.Name = "buttonSortByNewest";
            this.buttonSortByNewest.Size = new System.Drawing.Size(117, 23);
            this.buttonSortByNewest.TabIndex = 25;
            this.buttonSortByNewest.Text = "Sort By Newest";
            this.buttonSortByNewest.UseVisualStyleBackColor = true;
            // 
            // buttonSortByUser
            // 
            this.buttonSortByUser.Location = new System.Drawing.Point(33, 441);
            this.buttonSortByUser.Name = "buttonSortByUser";
            this.buttonSortByUser.Size = new System.Drawing.Size(117, 23);
            this.buttonSortByUser.TabIndex = 24;
            this.buttonSortByUser.Text = "Sort By User";
            this.buttonSortByUser.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(582, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(582, 60);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(248, 316);
            this.listBox4.TabIndex = 27;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Location = new System.Drawing.Point(12, 9);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(35, 13);
            this.labelUserInfo.TabIndex = 29;
            this.labelUserInfo.Text = "label5";
            // 
            // buttonUpdateCategory2
            // 
            this.buttonUpdateCategory2.Location = new System.Drawing.Point(33, 441);
            this.buttonUpdateCategory2.Name = "buttonUpdateCategory2";
            this.buttonUpdateCategory2.Size = new System.Drawing.Size(116, 23);
            this.buttonUpdateCategory2.TabIndex = 31;
            this.buttonUpdateCategory2.Text = "Update Category";
            this.buttonUpdateCategory2.UseVisualStyleBackColor = true;
            this.buttonUpdateCategory2.Click += new System.EventHandler(this.buttonUpdateCategory2_Click);
            // 
            // buttonCreateCategory2
            // 
            this.buttonCreateCategory2.Location = new System.Drawing.Point(33, 409);
            this.buttonCreateCategory2.Name = "buttonCreateCategory2";
            this.buttonCreateCategory2.Size = new System.Drawing.Size(116, 23);
            this.buttonCreateCategory2.TabIndex = 32;
            this.buttonCreateCategory2.Text = "Create Category";
            this.buttonCreateCategory2.UseVisualStyleBackColor = true;
            this.buttonCreateCategory2.Click += new System.EventHandler(this.buttonCreateCategory2_Click_1);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(585, 253);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 34;
            this.labelPrice.Text = "Price";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(582, 272);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 33;
            // 
            // buttonDeleteUsers
            // 
            this.buttonDeleteUsers.Location = new System.Drawing.Point(33, 470);
            this.buttonDeleteUsers.Name = "buttonDeleteUsers";
            this.buttonDeleteUsers.Size = new System.Drawing.Size(115, 23);
            this.buttonDeleteUsers.TabIndex = 35;
            this.buttonDeleteUsers.Text = "Delete User";
            this.buttonDeleteUsers.UseVisualStyleBackColor = true;
            this.buttonDeleteUsers.Click += new System.EventHandler(this.buttonDeleteUsers_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 526);
            this.Controls.Add(this.buttonDeleteUsers);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.buttonCreateCategory2);
            this.Controls.Add(this.buttonUpdateCategory2);
            this.Controls.Add(this.labelUserInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.buttonSortByValue);
            this.Controls.Add(this.buttonSortByNewest);
            this.Controls.Add(this.buttonSortByUser);
            this.Controls.Add(this.buttonCreateUser);
            this.Controls.Add(this.buttonUpdateUser);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonUpdateProduct);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDeleteCategory);
            this.Controls.Add(this.labelProductInfo);
            this.Controls.Add(this.checkBoxAvailable);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBoxProductInfo);
            this.Menu = this.mainMenu1;
            this.Name = "MainWindow";
            this.Text = "BackOffice";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemMenu;
        private System.Windows.Forms.MenuItem menuItemAccount;
        private System.Windows.Forms.MenuItem menuItemProducts;
        private System.Windows.Forms.MenuItem menuItemUsers;
        private System.Windows.Forms.MenuItem menuItemOrders;
        private System.Windows.Forms.MenuItem menuItemLogout;
        private System.Windows.Forms.MenuItem menuItemManage;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.CheckBox checkBoxAvailable;
        private System.Windows.Forms.TextBox textBoxProductInfo;
        private System.Windows.Forms.Label labelProductInfo;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUpdateProduct;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonUpdateUser;
        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.Button buttonSortByValue;
        private System.Windows.Forms.Button buttonSortByNewest;
        private System.Windows.Forms.Button buttonSortByUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label labelUserInfo;
        private System.Windows.Forms.Button buttonUpdateCategory2;
        private System.Windows.Forms.Button buttonCreateCategory2;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Button buttonDeleteUsers;
    }
}

