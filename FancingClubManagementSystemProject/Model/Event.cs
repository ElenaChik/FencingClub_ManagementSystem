using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancingClubManagementSystemProject.Model
{
    internal class Event
    {
        private int idEvent { get; set; }
        private string date { get; set; }
        private string time { get; set; }

        public Event() { }

        public Event(int idEvent, string date, string time)
        {
            this.idEvent = idEvent;
            this.date = date;
            this.time = time;
        }

        public Event getEvent() 
        {

            return new Event(); 
        }


    }
}
