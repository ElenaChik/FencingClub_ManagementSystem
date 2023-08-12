using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FancingClubManagementSystemProject.Controller
{
    internal class DBController
    {

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

        // connection adapter
        public static NpgsqlConnection con;
        // sql command adapter
        public static NpgsqlCommand cmd;

        /*
         * Method creates Connection String
         */
        private static string getConnectionString()
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
        public static void establishConnection()
        {
             // connection adapter
              //NpgsqlConnection con;
            // sql command adapter
              //NpgsqlCommand cmd;

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

        /*
         * Method runs string query with no parameters 
         */
        public static void runQuery(string query)
        {
            con.Open();

            // Define a query
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            con.Close();
        }

    }
}
