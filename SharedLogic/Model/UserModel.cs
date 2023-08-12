using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancingClubManagementSystemProject.Model 
{
    public class UserModel
    {
        public Users user = new Users();
        private List<Users> users;
        

        public UserModel() { }


        public int idUser { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Role role { get; set; }

    }
}
