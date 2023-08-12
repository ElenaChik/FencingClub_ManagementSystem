using FancingClubManagementSystemProject.DAO;
using FancingClubManagementSystemProject.DB;
using FancingClubManagementSystemProject.View;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using FancingClubManagementSystemProject.Model;
using System.Data;

namespace FancingClubManagementSystemProject.Service
{
    internal class FensingService
    {

        UserDAO userDAO = new UserDAO();
        MemberDAO memberDAO = new MemberDAO();

        public Boolean isLoginValid(string login, string password)
        {
            // 1. get user by login 
            string passwordDB = userDAO.getUserPasswordByLogin(login);

            // 2. Compare passwords
            return password != null && password.Equals(passwordDB);
        }

        /*
         * Method get Members Table
         */
        public DataView getMembersTable()
        {
            return memberDAO.getAllMembers().AsDataView();
        }


        public DataView getMemberById(string idMember)
        {
             return memberDAO.getMemberById(int.Parse(idMember)).AsDataView();
        }

        /*
         * Method add new Member
         */
        public void addMember(string nameFirst, string nameLast, string dateBirth,
            string phone, string email, string licenceNumber, string dateLicenceExpire)
        {
            memberDAO.addMember(nameFirst, nameLast, dateBirth, phone, email, licenceNumber, dateLicenceExpire);
        }

        public void updateMemberById(string nameFirst, string nameLast, string dateBirth,
            string phone, string email, string licenceNumber, string dateLicenceExpire, string idMember)
        {
            memberDAO.updateMemberByID(nameFirst, nameLast, dateBirth, phone, email, licenceNumber, dateLicenceExpire, int.Parse(idMember));
        }

        public void deleteMemberById(string idMember)
        {
            memberDAO.deleteMemberByID(int.Parse(idMember));
        }
    }
}
