using FancingClubManagementSystemProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLogic.Model
{
    public class ResponseAPI
    {
        public int statusCode {  get; set; }
        public string statusMessage { get; set; }
        public Registration registration { get; set; } // need parametrise
        public List<Registration> registrations { get; set; }

    }
}
