using FancingClubManagementSystemProject.DB;
using FancingClubManagementSystemProject.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FancingClubManagementSystemProject.DAO
{
    public class UserDAO
    {
        Connector connector = new Connector();

        /*
         * Metod get UserPasswordByLogin
         */
        public string getUserPasswordByLogin(string login)
        {
            connector.establishConnection();
            string password = null;
            try 
            { 
                connector.con.Open();

                var sql = "Select password from public.Users where login=@login ";

                connector.cmd = new NpgsqlCommand(sql, connector.con);
                connector.cmd.Parameters.AddWithValue("@login", login);

                var reader = connector.cmd.ExecuteReader();

                while (reader.Read())
                {
                    password = reader.GetString(0);
                }
                reader.Close();
            }
            finally 
            { 
                connector.con.Close(); 
            }

            return password;
        }
    }
}
