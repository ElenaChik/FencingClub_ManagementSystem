namespace FancingClubManagementSystemProject.Model
{
    public class Registration
    {
        public int idRegistration { get; set; }
        public string name { get; set; }
        public string contact { get; set; }
        public string startDate { get; set; }
        public string age { get; set; }

        public Registration() { }
        public Registration(string name, string contact, string age, string startdate ) 
        {
            //this.idRegistration = id;
            this.name = name;
            this.contact = contact;
            this.age = age;
            this.startDate = startdate;
        }

       // public Registration addRegistration()
        //{
       //     return new Registration( name, contact, age, startDate);
       // }

        public override string ToString()
        {
            return base.ToString() + ": " + idRegistration.ToString() + ", " + name + ", " + contact + " .";
        }

    }
}
