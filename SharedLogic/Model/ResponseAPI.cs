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
        public Member member { get; set; } 
        public List<Member> members { get; set; }

    }
}
