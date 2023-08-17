using FancingClubManagementSystemProject.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SharedLogic.DAO
{
    public class InventoryDAO
    {

        Connector connector = new Connector();

        /// <summary>
        /// Get All Inventory table
        /// </summary>
        /// <returns></returns>
        public DataTable getAllInventory()
        {
            DataTable dt = new DataTable();
            connector.establishConnection();
            try
            {
                connector.con.Open();

                string Query = "select * from public.Inventory ";

                connector.cmd = new NpgsqlCommand(Query, connector.con);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(connector.cmd);
                da.Fill(dt);

                connector.cmd.ExecuteNonQuery();
            }
            finally
            {
                connector.con.Close();
            }

            return dt;
        }
    }
}
