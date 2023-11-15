using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

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


        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Role();
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

                adapter.InsertCommand = new SqlCommand("sp_InsertUser", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 50, "UserID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserSurname", SqlDbType.NVarChar, 100, "UserSurname"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100, "UserName"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserPatronymic", SqlDbType.NVarChar, 100, "UserPatronymic"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserLogin", SqlDbType.NVarChar, 100, "UserLogin"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.NVarChar, 100, "UserPassword"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserRole", SqlDbType.Int, 50, "UserRole"));

                /*adapter.InsertCommand = new SqlCommand("sp_InsertRole", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleID", SqlDbType.Int, 50, "RoleID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 100, "RoleName"));

                adapter.InsertCommand = new SqlCommand("sp_InsertRole", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleID", SqlDbType.Int, 50, "RoleID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 100, "RoleName"));

                adapter.InsertCommand = new SqlCommand("sp_InsertRole", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleID", SqlDbType.Int, 50, "RoleID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 100, "RoleName"));

                adapter.InsertCommand = new SqlCommand("sp_InsertRole", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleID", SqlDbType.Int, 50, "RoleID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 100, "RoleName"));*/


                connection.Open();
                adapter.Fill(RoleTrade);
                RoleGrid.ItemsSource = RoleTrade.DefaultView;
                /*PickupGrid.ItemsSource = MelnichenkosaTrade.DefaultView;
                ProductGrid.ItemsSource = MelnichenkosaTrade.DefaultView;
                OrderGrid.ItemsSource = MelnichenkosaTrade.DefaultView;
                OrderProductGrid.ItemsSource = MelnichenkosaTrade.DefaultView;*/
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
    }
}
