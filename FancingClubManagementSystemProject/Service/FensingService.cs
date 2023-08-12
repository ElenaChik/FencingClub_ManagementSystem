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
    public class FensingService
    {

        UserDAO userDAO = new UserDAO();
        MemberDAO memberDAO = new MemberDAO();

      /// <summary>
      /// Get Password by Login from User
      /// </summary>
      /// <param name="login"></param>
      /// <returns>string password</returns>
        public string getPasswordByLogin(string login)
        {
            return userDAO.getUserPasswordByLogin(login);
        }

       /// <summary>
       /// Validate account by login and password
       /// </summary>
       /// <param name="login"></param>
       /// <param name="password"></param>
       /// <returns> Boolean
       /// </returns>
        public Boolean isLoginValid(string login, string password)
        {
            // 1. get user by login 
            string passwordDB = userDAO.getUserPasswordByLogin(login);

            // 2. Compare passwords
            return password != null && password.Equals(passwordDB);
        }

        /// <summary>
        /// Get Members Table
        /// </summary>
        /// <returns>DataView</returns>
        public DataView getMembersTable()
        {
            return memberDAO.getAllMembers().AsDataView();
        }

        /// <summary>
        /// Get Member by ID
        /// </summary>
        /// <param name="idMember"></param>
        /// <returns>DataView Member</returns>
        public DataView getMemberById(string idMember)
        {
             return memberDAO.getMemberById(int.Parse(idMember)).AsDataView();
        }

      /// <summary>
      /// Add new Member 
      /// </summary>
      /// <param name="nameFirst"></param>
      /// <param name="nameLast"></param>
      /// <param name="dateBirth"></param>
      /// <param name="phone"></param>
      /// <param name="email"></param>
      /// <param name="licenceNumber"></param>
      /// <param name="dateLicenceExpire"></param>
        public void addMember(string nameFirst, string nameLast, string dateBirth,
            string phone, string email, string licenceNumber, string dateLicenceExpire)
        {
            memberDAO.addMember(nameFirst, nameLast, dateBirth, phone, email, licenceNumber, dateLicenceExpire);
        }

        /// <summary>
        /// Update Member by ID
        /// </summary>
        /// <param name="nameFirst"></param>
        /// <param name="nameLast"></param>
        /// <param name="dateBirth"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="licenceNumber"></param>
        /// <param name="dateLicenceExpire"></param>
        /// <param name="idMember"></param>
        public void updateMemberById(string nameFirst, string nameLast, string dateBirth,
            string phone, string email, string licenceNumber, string dateLicenceExpire, string idMember)
        {
            memberDAO.updateMemberByID(nameFirst, nameLast, dateBirth, phone, email, licenceNumber, dateLicenceExpire, int.Parse(idMember));
        }

        /// <summary>
        /// Delete Member by ID
        /// </summary>
        /// <param name="idMember"></param>
        public void deleteMemberById(string idMember)
        {
            memberDAO.deleteMemberByID(int.Parse(idMember));
        }
    }
}
