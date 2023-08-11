using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancingClubManagementSystemProject.Model
{
    public partial class Users
    {
        public int idUser { get; set; }
        public int name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string dateCreated { get; set; }
    }
}
