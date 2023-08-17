using FancingClubManagementSystemProject.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SharedLogic.DAO
{
    public class ClassAttendanceDAO
    {
        Connector connector = new Connector();

        public void addClassAttendance(string date, int idGroup, int idCoach, int idMember)
        {
            connector.establishConnection();
            try
            {
                connector.con.Open();

                string Query = "insert into public.ClassAttendance ( date,  idGroup,  idCoach,  idMember) " +
                    " values (@date, @group, @coach, @idMember) ";

                connector.cmd = new NpgsqlCommand(Query, connector.con);

                connector.cmd.Parameters.AddWithValue("@date", date);
                connector.cmd.Parameters.AddWithValue("@idGroup", idGroup);
                connector.cmd.Parameters.AddWithValue("@idCoach", idCoach);
                connector.cmd.Parameters.AddWithValue("@idMember", idMember);

                connector.cmd.ExecuteNonQuery();
            }
            finally
            {
                connector.con.Close();
            }
        }

        public DataTable getAllAttendance()
        {
            DataTable dt = new DataTable();
            connector.establishConnection();
            try
            {
                connector.con.Open();

                string Query = "select * from public.ClassAttendance ";

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
