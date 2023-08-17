using FancingClubManagementSystemProject.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FancingClubManagementSystemProject.DAO
{
    public class ExtraDAO
    {
        Connector connector = new Connector();

        /// <summary>
        /// Create Member Table if not exist
        /// </summary>
        public void createMemberTable()
        {
            connector.establishConnection();
            try
            {
                connector.con.Open();

                var sql = $"CREATE TABLE if not exists Member " +
                $"(" +
                $"idMember serial PRIMARY KEY, " +
                $"nameFirst VARCHAR (100), " +
                $"nameLast VARCHAR (100), " +
                $"dateBirth VARCHAR (100), " +
                $"phone VARCHAR (100), " +
                $"email VARCHAR (100), " +
                $"licenceNumber VARCHAR (100), " +
                $"dateLicenceExpire VARCHAR (100), " +
                $"dateRegistration timestamp " +
                $"image BYTEA " +
                $"groupe VARCHAR (100) " +
                $"coach VARCHAR (100) " +
                $")";

                connector.cmd = new NpgsqlCommand(sql, connector.con);
                connector.cmd.ExecuteNonQuery(); 
            }
            finally
            {
                connector.con.Close();
            }
        }


        public async Task CreateTableUser()
        {
            connector.establishConnection();
            try
            {
                connector.con.Open();

                var sql = $"CREATE TABLE if not exists Users " +
                $"(" +
                $"idMember serial PRIMARY KEY, " +
                $"name VARCHAR (100) NOT NULL, " +
                $"login VARCHAR (100) NOT NULL, " +
                $"password VARCHAR (100) NOT NULL, " +
                $"dateCreated timestamp " +
                $")";

                connector.cmd = new NpgsqlCommand(sql, connector.con);
                await connector.cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                connector.con.Close();
            }
        }

        public void createRegistrationTable()
        {
            connector.establishConnection();
            try
            {
                connector.con.Open();

                var sql = $"CREATE TABLE if not exists Registration " +
                $"(" +
                $"idRegistration serial PRIMARY KEY, " +
                $"name VARCHAR (100), " +
                $"contact VARCHAR (100), " +
                $"startDate VARCHAR (100), " +
                $"age VARCHAR (100) " +
                $")";

                connector.cmd = new NpgsqlCommand(sql, connector.con);
                connector.cmd.ExecuteNonQuery();
            }
            finally
            {
                connector.con.Close();
            }
        }
    }
}
