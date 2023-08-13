using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancingClubManagementSystemProject.Model
{
    public class Member 
    {
        public string idMember { get; set; }
        public string nameFirst { get; set; }
        public string nameLast { get; set; }
        public string dateBirth { get; set; }
        public string phone { get; set; }

        public string email { get; set; }
        public string licenceNumber { get; set; }
        public string dateLicenceExpire { get; set; }
        public string dateRegistration { get; set; }
        public string group { get; set; }
        public string coach { get; set; }
        public string image { get; set; }

        public Member() { }


        public override string ToString()
        {
            return base.ToString() + ": " + idMember.ToString() + ", " + nameFirst ;
        }
    }
}
