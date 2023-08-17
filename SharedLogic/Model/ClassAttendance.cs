using FancingClubManagementSystemProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLogic.Model
{
    public class ClassAttendance
    {
        public int idAttendance { get; set; }

        public string date { get; set;}
        public int idGroup { get; set;}
        public int idCoach { get; set;}

        public int idMember { get; set;}


    }
}
