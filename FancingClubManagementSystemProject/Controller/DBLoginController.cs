using FancingClubManagementSystemProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FancingClubManagementSystemProject.Controller
{
    internal class DBLoginController
    {
        DBController dbc = new DBController();


        /*
         * Method get User by Login
         */
        public Users getUserByLogin(string inpLogin) {

           // Model.User user = null; 
            DBController.establishConnection();

            Users user = new Users();

            try
            {
                DBController.con.Open();
                String Query = "select * from public.\"User\" where login=@inpLogin";
                DBController.cmd = new Npgsql.NpgsqlCommand(Query, DBController.con);
                DBController.cmd.Parameters.AddWithValue("@inpLogin", inpLogin);

                var reader = DBController.cmd.ExecuteReader();

                reader.GetValue(0);
                //user = reader;
                

            } catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


            return user;
            }
    }
}
