using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancingClubManagementSystemProject.Controller
{
    internal class MnageUsersController
    {



        /*
         * Method shows a table of all Members
         */
        public void getAllMembers()
        {
            //select * from Users
        }

        public void getMembersByFilter(string id, string nameLast) 
        {
            //select * from Users where id=@ID, name=@nameLast
        }

        /*
        *  Method shows Member's info when Member is choosen in the Table
        */
        public void getMemberInfo(string id)
        {
            // get Member object ID choosen in the table
            // call dbService 
            // show all info in the Member info card
        }

        /*
         * Method add new Member with all info to db
         */
        public void addMember()
        { 
            // check if Login already exist
            // take input fields
            // add all fields values to db (INSERT into Members values(@nameFirst, @nameLast)
        }

        /*
      * Method update Member's info in db. Login can't be updated
      */
        public void updateMember()
        {
            // get Member object choosen in the table
            // take input fields
            // add all fields values to db (UPDATE into Members values(@nameFirst, @nameLast)
        }

        /*
        * Method delete from db the Member that was choosen in the table 
        */
        public void deleteMember()
        {
            // get Member object choosen in the table
        }

       
       

    }
}
