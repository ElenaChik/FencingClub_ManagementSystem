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
    internal class ExtraDAO
    {
        Connector connector = new Connector();


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
                $")";

                connector.cmd = new NpgsqlCommand(sql, connector.con);
                connector.cmd.ExecuteNonQuery();
                //connector.cmd.Parameters.AddWithValue("@login", login);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connector.con.Close();
            }
        }
       
    }
}
