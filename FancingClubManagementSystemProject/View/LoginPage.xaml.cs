using Npgsql;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FancingClubManagementSystemProject.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {

        private static string getConnectionStringLogPage()
        {
            // in this method, we are going to create a connection string for the PostGreSQL server..
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=FencingClubManagementSystem;";
            string userName = "Username=postgres;";
            string password = "Password=1111;";
            // Now we need to add all these values/strings to one string, means we are going to merge
            // the strings together and going to create our string
            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;
        }

        // connection adapter
        public static NpgsqlConnection con;

        // sql command adapter
        public static NpgsqlCommand cmd;
        private static void establishConnection()
        {
            // in establishing database connection, you need to use exception handling, because it helps
            // to detect if somehow the connection fails or your database server is not going to be 
            // connected

            try
            {
                // create the connection
                con = new NpgsqlConnection(getConnectionStringLogPage());

                /*
                 * we actually need to pass the connectionString inside the NpgsqlConnection adapter
                 * class constructor. To do so, we are calling the getConnectionString() method as 
                 * this method returns us the Database connection String we have created for 
                 * our work. 
                 */
                MessageBox.Show("Database Connection Successful");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public LoginPage()
        {
            InitializeComponent();
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            
             // establish connection
            establishConnection();
            try
            {
                // open the connection
                con.Open();

                // create the SQL query
                string Query = "insert into public.\"User\" values (default, @login, @password, @role, current_timestamp) ";

                // create sql Command 
                cmd = new NpgsqlCommand(Query, con); // this is the command adapter, we need to pass
                                                     // two values in the adapter, one is the query,
                                                     // another one is the connection itself

                // we now need to add the values for the parameters in the sql query

                // cmd.Parameters.AddWithValue("@id", int.Parse("DEFAULT"));
                cmd.Parameters.AddWithValue("@login", loginBox.Text);
                cmd.Parameters.AddWithValue("@password", passBox.Password);
                cmd.Parameters.AddWithValue("@role", "Role");
                // cmd.Parameters.AddWithValue("@dateCreated", 2023-01-01);

                // execute the Query
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Insertion Successful");
                // close the Connection
                con.Close();

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            establishConnection();

            try
            {
                con.Open();

                string Query = "Select * from public.\"User\"";

                cmd = new NpgsqlCommand(Query, con);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                tableDataGrid.ItemsSource = dt.AsDataView();

                DataContext = da;

                con.Close();

            } catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
