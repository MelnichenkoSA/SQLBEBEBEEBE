using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SQLBEBEBEEBE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable RoleTrade;
        DataTable UserTrade;
        DataTable PickupTrade;
        DataTable ProductTrade;
        DataTable OrderTrade;
        DataTable OrderProductTrade;
        DataTable Userki;


        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Autorize passwordWindow = new Autorize();

            if (passwordWindow.ShowDialog() == true)
            {
                DataTable Logsword = Select("SELECT * FROM [User] WHERE UserLogin = '" + passwordWindow.Login + "' AND UserPassword = '" + passwordWindow.Password + "'");
                if (Logsword.Rows.Count > 0)
                {
                    DataTable userRole = Select("select UserRole from [User] where UserLogin = '" + passwordWindow.Login + "'");
                    int i = Convert.ToInt32(userRole.Rows[0][0]);
                    DataTable role = Select("select * from Role where RoleId = '" + i + "'");
                    string j = Convert.ToString(role.Rows[0][1]);
                    MessageBox.Show("Авторизация пройдена, ваша роль: " + j);

                }
                else
                    MessageBox.Show("Неверный пароль или логин");
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Role();
            User();
            Pickup();
            Product();
            Order();
            OrderProduct();
        }

        public void Role()
        {
            string sql = "SELECT * FROM Role";
            RoleTrade = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertRole", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleID", SqlDbType.Int, 50, "RoleID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 100, "RoleName"));

                connection.Open();
                adapter.Fill(RoleTrade);
                RoleGrid.ItemsSource = RoleTrade.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public void User()
        {
            string sql = "SELECT * FROM [User]";
            UserTrade = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertUser", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 50, "UserID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserSurname", SqlDbType.NVarChar, 100, "UserSurname"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100, "UserName"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserPatronymic", SqlDbType.NVarChar, 100, "UserPatronymic"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserLogin", SqlDbType.NVarChar, 100, "UserLogin"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.NVarChar, 100, "UserPassword"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserRole", SqlDbType.Int, 50, "UserRole"));

                connection.Open();
                adapter.Fill(UserTrade);
                UserGrid.ItemsSource = UserTrade.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public void Pickup()
        {
            string sql = "SELECT * FROM PickupPoint";
            PickupTrade = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertPickupPoint", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@PointID", SqlDbType.Int, 50, "PointID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@PointAddress", SqlDbType.NVarChar, 100, "PointAddress"));

                connection.Open();
                adapter.Fill(PickupTrade);
                PickupGrid.ItemsSource = PickupTrade.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public void Product()
        {
            string sql = "SELECT * FROM Product";
            ProductTrade = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertProduct", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductArticleNumber", SqlDbType.NVarChar, 100, "ProductArticleNumber"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar, 100, "ProductName"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductDescription", SqlDbType.NVarChar, 100, "ProductDescription"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductCategory", SqlDbType.NVarChar, 100, "ProductCategory"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductPhoto", SqlDbType.NVarChar, 100, "ProductPhoto"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductManufacturer", SqlDbType.NVarChar, 100, "ProductManufacturer"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductCost", SqlDbType.Decimal, 20, "ProductCost"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductDiscountAmount", SqlDbType.Int, 100, "ProductDiscountAmount"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductQuantityInStock", SqlDbType.Int, 100, "ProductQuantityInStock"));

                connection.Open();
                adapter.Fill(ProductTrade);
                ProductGrid.ItemsSource = ProductTrade.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public void Order()
        {
            string sql = "SELECT * FROM [Order]";
            OrderTrade = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertOrder", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.Int, 50, "OrderID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrderStatus", SqlDbType.NVarChar, 100, "OrderStatus"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrderDeliveryDate", SqlDbType.DateTime, 100, "OrderDeliveryDate"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrderPickupPoint", SqlDbType.Int, 100, "OrderPickupPoint"));

                connection.Open();
                adapter.Fill(OrderTrade);
                OrderGrid.ItemsSource = OrderTrade.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public void OrderProduct()
        {
            string sql = "SELECT * FROM OrderProduct";
            OrderProductTrade = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertOrderProduct", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.Int, 50, "OrderID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductArticleNumber", SqlDbType.NVarChar, 100, "ProductArticleNumber"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@NumberProduct", SqlDbType.Int, 50, "NumberProduct"));

                connection.Open();
                adapter.Fill(OrderProductTrade);
                OrderProductGrid.ItemsSource = OrderProductTrade.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public DataTable Select(string sql)
        {
            Userki = new DataTable();
            SqlConnection connection = null;
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);

            adapter.InsertCommand = new SqlCommand("sp_InsertUserki", connection);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            connection.Open();
            adapter.Fill(Userki);
            return Userki;
        }
    }
}
