namespace UniversityCounsellingSystemAPI.Models.Entities
{
    public class Counsellor: User
    {
        private string professional_qualifications;



        public Counsellor(string email) : base(email)
        {
        }

        public Counsellor(string email, string professional_qualifications) : base(email)
        {
            Professional_qualifications = professional_qualifications;
        }

    

        public string Professional_qualifications { get => professional_qualifications; set => professional_qualifications = value; }

        public override string ToString()
        {
            return email + " " + name + " " + Professional_qualifications + " " + Contact_No;
        }
    }
}
