using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler
{
    public static class SQL
    {
        const string conStr = "Server=tcp:dinotest.database.windows.net,1433;Data Source=dinotest.database.windows.net;Initial Catalog=eCommercePlattform;Persist Security Info=False;User ID=dino;Password=HJOhjo1991;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static SqlConnection connection = new SqlConnection(conStr);

        public static bool CheckLogin(string username, string password)
        {
            bool ret = false;

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"select [Password] from [User] where Username = {username}";

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    if (password.Equals(reader["Password"].ToString()))
                        ret = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return ret;
        }

        public static int CreateUser(string firstname, string lastname, string email, string username, string password, string street, string zip, string city)
        {
            int newID = 0;

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spCreateUser";

                SqlParameter _firstname = new SqlParameter("@Firstname", SqlDbType.VarChar);
                _firstname.Value = firstname;
                command.Parameters.Add(_firstname);

                SqlParameter _lastname = new SqlParameter("@Lastname", SqlDbType.VarChar);
                _lastname.Value = lastname;
                command.Parameters.Add(_lastname);

                SqlParameter _email = new SqlParameter("@Email", SqlDbType.VarChar);
                _email.Value = email;
                command.Parameters.Add(_email);

                SqlParameter _username = new SqlParameter("@Username", SqlDbType.VarChar);
                _username.Value = username;
                command.Parameters.Add(_username);

                SqlParameter _password = new SqlParameter("@Password", SqlDbType.VarChar);
                _password.Value = password;
                command.Parameters.Add(_password);

                SqlParameter _street = new SqlParameter("@Street", SqlDbType.VarChar);
                _street.Value = street;
                command.Parameters.Add(_street);

                SqlParameter _zip = new SqlParameter("@PostalCode", SqlDbType.VarChar);
                _zip.Value = zip;
                command.Parameters.Add(_zip);

                SqlParameter _city = new SqlParameter("@City", SqlDbType.VarChar);
                _city.Value = city;
                command.Parameters.Add(_city);

                SqlParameter _newId = new SqlParameter("@new_UID", SqlDbType.Int);
                _newId.Direction = ParameterDirection.Output;
                command.Parameters.Add(_newId);

                command.ExecuteNonQuery();

                newID = (int)_newId.Value;
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return newID;
        }

        public static int CreateAddress(int userId, string street, string zip, string city)
        {
            int newID = 0;

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spCreateAddress";

                SqlParameter _userId = new SqlParameter("@UserId", SqlDbType.Int);
                _userId.Value = userId;
                command.Parameters.Add(_userId);

                SqlParameter _street = new SqlParameter("@Street", SqlDbType.VarChar);
                _street.Value = street;
                command.Parameters.Add(_street);

                SqlParameter _zip = new SqlParameter("@PostalCode", SqlDbType.VarChar);
                _zip.Value = zip;
                command.Parameters.Add(_zip);

                SqlParameter _city = new SqlParameter("@City", SqlDbType.VarChar);
                _city.Value = city;
                command.Parameters.Add(_city);

                SqlParameter _newId = new SqlParameter("@new_AID", SqlDbType.Int);
                _newId.Direction = ParameterDirection.Output;
                command.Parameters.Add(_newId);

                command.ExecuteNonQuery();

                newID = (int)_newId.Value;
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return newID;
        }

        public static int CreateOrder(int userId)
        {
            int newID = 0;

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spCreateAddress";

                SqlParameter _userId = new SqlParameter("@UserId", SqlDbType.Int);
                _userId.Value = userId;
                command.Parameters.Add(_userId);

                SqlParameter _date = new SqlParameter("@OrderDate", SqlDbType.DateTime);
                _date.Value = DateTime.Now;
                command.Parameters.Add(_date);

                SqlParameter _newId = new SqlParameter("@new_OID", SqlDbType.Int);
                _newId.Direction = ParameterDirection.Output;
                command.Parameters.Add(_newId);

                command.ExecuteNonQuery();

                newID = (int)_newId.Value;
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return newID;
        }

        public static int CreateProduct(string name, string desc, int catId)
        {
            int newID = 0;

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spCreateProduct";

                SqlParameter _name = new SqlParameter("@Name", SqlDbType.VarChar);
                _name.Value = name;
                command.Parameters.Add(_name);

                SqlParameter _desc = new SqlParameter("@Desc", SqlDbType.VarChar);
                _desc.Value = desc;
                command.Parameters.Add(_desc);

                SqlParameter _catId = new SqlParameter("@CatId", SqlDbType.Int);
                _catId.Value = catId;
                command.Parameters.Add(_catId);

                SqlParameter _newId = new SqlParameter("@new_ProdId", SqlDbType.Int);
                _newId.Direction = ParameterDirection.Output;
                command.Parameters.Add(_newId);

                command.ExecuteNonQuery();

                newID = (int)_newId.Value;
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return newID;
        }

        public static Dictionary<string, List<string>> LoadProducts(string category)
        {
            Dictionary<string, List<string>> products = new Dictionary<string, List<string>>();
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"select * from category as c left outer join product as p on c.id = p.category where c.title = '{category}'";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    List<string> temp = new List<string>();
                    
                    temp.Add(reader["Price"].ToString());
                    temp.Add(reader["Description"].ToString());

                    products.Add(reader["Name"].ToString(), temp);
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return products;
        }
    }
}