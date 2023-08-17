using FancingClubManagementSystemProject.DB;
using FancingClubManagementSystemProject.Model;
using Npgsql;
using System.Data;

namespace FancingClubManagementSystemProject.DAO
{
    public class MemberDAO
    {
        Connector connector = new Connector();

        /// <summary>
        /// Get All Members table
        /// </summary>
        /// <returns></returns>
        public DataTable getAllMembers()
        {
            DataTable dt = new DataTable();
            connector.establishConnection();
            try
            {
                connector.con.Open();

                string Query = "select * from public.Member ";

                connector.cmd = new NpgsqlCommand(Query, connector.con);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(connector.cmd);
                da.Fill(dt);

                connector.cmd.ExecuteNonQuery();
                //MessageBox.Show("Data Update Successful");
            }
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            finally
            {
                connector.con.Close();
            }

            return dt;
        }

       /// <summary>
       /// Get Member by ID. Represent result as Member Info page
       /// </summary>
       /// <param name="idMember"></param>
       /// <returns></returns>
        public Member getMemberInfoById(int idMember)
        {
            DataTable dt = new DataTable();
            connector.establishConnection();
            Member member = null;
            try
            {
                connector.con.Open();

                var sql = "Select * from public.Member where idMember=@idMember ";

                connector.cmd = new NpgsqlCommand(sql, connector.con);
                connector.cmd.Parameters.AddWithValue("@idMember", idMember);

                /*
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(connector.cmd);
                da.Fill(dt);
                */
                //membersTable.ItemsSource = dt.AsDataView();
               // DataContext = da;

                
                var reader = connector.cmd.ExecuteReader();

                while (reader.Read())
                {
                    member = new Member();
                    //member.idMember = reader.GetString(0);
                    member.nameFirst = reader.GetString(1);
                    member.nameLast = reader.GetString(2);
                    member.dateBirth = reader.GetString(3);
                    member.phone = reader.GetString(4);
                    member.email = reader.GetString(5);
                    member.licenceNumber = reader.GetString(6);
                    member.dateLicenceExpire = reader.GetString(7);
                    //member.dateRegistration = reader.GetString(8);

                }
                reader.Close();
                
            }
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            finally
            {
                connector.con.Close();
            }

            return member;
        }

        public DataTable filterMembersById(int idMember)
        {
            DataTable dt = new DataTable();
            connector.establishConnection();
            Member member = null;
            try
            {
                connector.con.Open();

                var sql = "Select * from public.Member where idMember=@idMember ";

                connector.cmd = new NpgsqlCommand(sql, connector.con);
                connector.cmd.Parameters.AddWithValue("@idMember", idMember);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(connector.cmd);
                da.Fill(dt);

                //membersTable.ItemsSource = dt.AsDataView();
                // DataContext = da;


                /*var reader = connector.cmd.ExecuteReader();

                while (reader.Read())
                {
                    member = new Member();
                    member.idMember = reader.GetInteger(0);
                    member.nameFirst = reader.GetString(1);
                    member.nameLast = reader.GetString(2);
                    member.dateBirth = reader.GetString(3);
                    member.phone = reader.GetString(4);
                    member.email = reader.GetString(5);
                    member.licenceNumber = reader.GetString(6);
                    member.dateLicenceExpire = reader.GetString(7);
                    member.dateRegistration = reader.GetString(8);

                }
                reader.Close();*/

            }
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            finally
            {
                connector.con.Close();
            }

            return dt;
        }

        /*
         * Method addMember to DB
         */
        public void addMember(string nameFirst, string nameLast, string dateBirth, 
            string phone, string email, string licenceNumber, string dateLicenceExpire) 
        {
            connector.establishConnection();
            try
            {
                connector.con.Open();

                string Query = "insert into public.Member (nameFirst, nameLast, " +
                    "dateBirth, phone, email, licenceNumber, dateLicenceExpire)" +
                    " values (@nameFirst, @nameLast, @dateBirth, @phone, @email, @licenceNumber, " +
                    "@dateLicenceExpire) ";

                connector.cmd = new NpgsqlCommand(Query, connector.con);

                connector.cmd.Parameters.AddWithValue("@nameFirst", nameFirst);
                connector.cmd.Parameters.AddWithValue("@nameLast", nameLast);
                connector.cmd.Parameters.AddWithValue("@dateBirth", dateBirth);
                connector.cmd.Parameters.AddWithValue("@phone", phone);
                connector.cmd.Parameters.AddWithValue("@email", email);
                connector.cmd.Parameters.AddWithValue("@licenceNumber", licenceNumber);
                connector.cmd.Parameters.AddWithValue("@dateLicenceExpire", dateLicenceExpire);
         

                connector.cmd.ExecuteNonQuery();
                //MessageBox.Show("Data Insertion Successful");
            }
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            finally
            {
                connector.con.Close();
            }
        }



        public void updateMemberByID(string nameFirst, string nameLast, string dateBirth,
            string phone, string email, string licenceNumber, string dateLicenceExpire, string groupe, string coach, int idMember)
            {
                connector.establishConnection();
                try
                {
                    connector.con.Open();

                    string Query = "update public.Member set nameFirst=@nameFirst, nameLast=@nameLast, " +
                        "dateBirth=@dateBirth, phone=@phone, email=@email, licenceNumber=@licenceNumber, " +
                        "dateLicenceExpire=@dateLicenceExpire, groupe=@groupe, coach=@coach " +
                        "  where idMember=@idMember ";

                    connector.cmd = new NpgsqlCommand(Query, connector.con);

                    connector.cmd.Parameters.AddWithValue("@nameFirst", nameFirst);
                    connector.cmd.Parameters.AddWithValue("@nameLast", nameLast);
                    connector.cmd.Parameters.AddWithValue("@dateBirth", dateBirth);
                    connector.cmd.Parameters.AddWithValue("@phone", phone);
                    connector.cmd.Parameters.AddWithValue("@email", email);
                    connector.cmd.Parameters.AddWithValue("@licenceNumber", licenceNumber);
                    connector.cmd.Parameters.AddWithValue("@dateLicenceExpire", dateLicenceExpire);
                    connector.cmd.Parameters.AddWithValue("@groupe", groupe);
                    connector.cmd.Parameters.AddWithValue("@coach", coach);
                    connector.cmd.Parameters.AddWithValue("@idMember", idMember);

                    connector.cmd.ExecuteNonQuery();
                    //MessageBox.Show("Data Update Successful");
                }
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            finally
            {
                connector.con.Close();
            }
            
        }
        public void deleteMemberByID(int idMember)
        {
            connector.establishConnection();
            try
            {
                connector.con.Open();

                string Query = "delete from public.Member where idMember=@idMember ";

                connector.cmd = new NpgsqlCommand(Query, connector.con);

                connector.cmd.Parameters.AddWithValue("@idMember", idMember);

                connector.cmd.ExecuteNonQuery();
                //MessageBox.Show("Data Deleted Successful");
            }
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            finally
            {
                connector.con.Close();
            }
        }
    }
}
