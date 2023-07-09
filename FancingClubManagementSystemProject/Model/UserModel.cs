using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancingClubManagementSystemProject.Model
{
    internal class UserModel
    {
        public User user = new User();

        public int idUser { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public Role role { get; set; }

    }
}
