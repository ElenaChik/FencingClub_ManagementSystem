using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using FancingClubManagementSystemProject.DAO;
using FancingClubManagementSystemProject.DB;
using FancingClubManagementSystemProject.Model;
using FancingClubManagementSystemProject.Service;
using FancingClubManagementSystemProject.View;
using Npgsql;

namespace FancingClubManagementSystemProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FensingService fs = new FensingService();

        // connection adapter
        //public NpgsqlConnection con;
        // sql command adapter
        //public NpgsqlCommand cmd;

        /*
       * Database Connection & Operation
       * 
       * 1. Database connection with the Connection String (Need to Form)
       * 2. Establish the DB Connection
       * -- Open the Connection
       * 3. Generate the SQL Command for performing SQL Operations
       * 4. Execute the Command
       * 5. Close the Connection to Save the Results
       * 
       */



        /*
         * Method creates Connection String
         */
        /*private static string getConnectionString()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=FencingClubManagementSystem;";
            string userName = "Username=postgres;";
            string password = "Password=1111;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;
        }

        /*
         * Method establish database connection using exeptions
         */
       /* private static void establishConnection()
        {
            try
            {
                // create the connection
                con = new NpgsqlConnection(getConnectionString());

                MessageBox.Show("Database Connection Successful");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       */


        public MainWindow()
        {
            InitializeComponent();
            //ExtraDAO extraDAO = new ExtraDAO();
            //MemberDAO memberDAO = new MemberDAO();

            //extraDAO.createMemberTable();
            
        }

       

        /*
         * Method give access to Manage User Panel. First checking login and password
         */
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

            if (fs.isLoginValid(loginBox1.Text, passwordBox.Password))
            {
                ManageUsersPanel manageUser = new ManageUsersPanel();
                manageUser.Show();
                this.Close();
            }
                else
            {
                MessageBox.Show("Invalid login or password");
            }

        }

       /* public async Task<Users> readUsers(int idUser)
        {
            Task<Users> user = null;
            await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                     Users users = await readUsers(reader);
                    //login = reader[0].ToString();
                   // password = reader[1].ToString();
                    //idUser  = reader[2].ToString;
                }
            }
            return null;
        }
       */


    
    }
}
