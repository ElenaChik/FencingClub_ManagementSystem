using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FancingClubManagementSystemProject.DB
{
    public class Connector
    {
        // connection adapter
        public NpgsqlConnection con;
        // sql command adapter
        public NpgsqlCommand cmd;

        /*
         * Method creates Connection String
         */
        private string getConnectionString()
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
        public void establishConnection()
        {
            // connection adapter
            //NpgsqlConnection con;
            // sql command adapter
            //NpgsqlCommand cmd;

            //try
            //{
                // create the connection
                con = new NpgsqlConnection(getConnectionString());
                //con.Open();

                //MessageBox.Show("Database Connection Successful");
            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

    }
}
