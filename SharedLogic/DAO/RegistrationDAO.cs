using FancingClubManagementSystemProject.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SharedLogic.DAO
{
    public class RegistrationDAO
    {
        Connector connector = new Connector();
        public void addRegistration (string name, string contact, string startDate, string age)
        {
        connector.establishConnection();
        try
        {
        connector.con.Open();

        string Query = "insert into public.Registration (name, contact, startDate, age) " +
                        " values (@name, @contact, @startDate, @age) ";
                    connector.cmd = new NpgsqlCommand(Query, connector.con);

                    connector.cmd.Parameters.AddWithValue("@name", name);
                    connector.cmd.Parameters.AddWithValue("@contact", contact);
                    connector.cmd.Parameters.AddWithValue("@startDate", startDate);
                    connector.cmd.Parameters.AddWithValue("@age", age); 

                    connector.cmd.ExecuteNonQuery();
                    //MessageBox.Show("Data Insertion Successful");
                }
               // catch (NpgsqlException ex)
               //{
               //     MessageBox.Show(ex.Message);
                //}
              finally
              {
                  connector.con.Close();
              }
        }

        public DataTable getAllRegistration()  //.......
        {
            DataTable dt = new DataTable();
            connector.establishConnection();
            try
            {
                connector.con.Open();

                string Query = "select * from public.Registration ";
                connector.cmd = new NpgsqlCommand(Query, connector.con);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(connector.cmd);
                da.Fill(dt);

                connector.cmd.ExecuteNonQuery();

                //connector.cmd.Parameters.AddWithValue("@name", name);
                //connector.cmd.Parameters.AddWithValue("@contact", contact);
                //connector.cmd.Parameters.AddWithValue("@startDate", startDate);
                //connector.cmd.Parameters.AddWithValue("@age", age);

                //MessageBox.Show("Data Insertion Successful");
            }
            // catch (NpgsqlException ex)
            //{
            //     MessageBox.Show(ex.Message);
            //}
            finally
            {
                connector.con.Close();
            }
            return dt;
        }


    }
}
