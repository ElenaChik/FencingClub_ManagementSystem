using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using FancingClubManagementSystemProject.Model;
using System.Data;
using FancingClubManagementSystemProject.DB;
using FancingClubManagementSystemProject.View;

namespace FancingClubManagementSystemProject.DAO
{
    public class MemberDAO
    {
        Connector connector = new Connector();

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

                connector.con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        /*
         * Method get Member by Id
         */
        public DataTable getMemberById(int idMember)
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
                    member.idUser = reader.GetString(0);
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
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                connector.con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void updateMemberByID(string nameFirst, string nameLast, string dateBirth,
            string phone, string email, string licenceNumber, string dateLicenceExpire, int idMember)
            {
                connector.establishConnection();
                try
                {
                    connector.con.Open();

                    string Query = "update public.Member set nameFirst=@nameFirst, nameLast=@nameLast, " +
                        "dateBirth=@dateBirth, phone=@phone, email=@email, licenceNumber=@licenceNumber, " +
                        "dateLicenceExpire=@dateLicenceExpire  where idMember=@idMember ";

                    connector.cmd = new NpgsqlCommand(Query, connector.con);

                    connector.cmd.Parameters.AddWithValue("@nameFirst", nameFirst);
                    connector.cmd.Parameters.AddWithValue("@nameLast", nameLast);
                    connector.cmd.Parameters.AddWithValue("@dateBirth", dateBirth);
                    connector.cmd.Parameters.AddWithValue("@phone", phone);
                    connector.cmd.Parameters.AddWithValue("@email", email);
                    connector.cmd.Parameters.AddWithValue("@licenceNumber", licenceNumber);
                    connector.cmd.Parameters.AddWithValue("@dateLicenceExpire", dateLicenceExpire);
                    connector.cmd.Parameters.AddWithValue("@idMember", idMember);

                    connector.cmd.ExecuteNonQuery();
                    //MessageBox.Show("Data Update Successful");

                    connector.con.Close();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
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

                connector.con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
