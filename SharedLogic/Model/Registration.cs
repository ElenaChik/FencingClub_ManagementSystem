namespace FancingClubManagementSystemProject.Model
{
    public class Registration
    {
        private int idRegistration { get; set; }
        private string name { get; set; }
        private string contact { get; set; }

        private string  age { get; set; }
        private string startDate { get; set; }

        public Registration() { }
        public Registration(string name, string contact, string age, string startdate ) 
        {
            //this.idRegistration = id;
            this.name = name;
            this.contact = contact;
            this.age = age;
            this.startDate = startdate;
        }

        public Registration addRegistration()
        {
            return new Registration( name, contact, age, startDate);
        }

        public override string ToString()
        {
            return base.ToString() + ": " + idRegistration.ToString() + ", " + name + ", " + contact + " .";
        }

    }
}
