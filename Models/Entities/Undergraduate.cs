using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace UniversityCounsellingSystemAPI.Models.Entities
{
    public class Undergraduate : User
    {
        public int universityId;
        private string dob;
        private string degree;
        private string academicYear;

        public int UniversityId
        {
            get => universityId; set
            {
                if (value != null)
                {
                    universityId = value;
                }
                else
                {
                    throw new InvalidDataException("Please enter valid details.");
                }
            }

        }
        public string Dob { get => dob; set => dob = value; }
        public string Degree { get => degree; set => degree = value; }
        public string AcademicYear { get => academicYear; set => academicYear = value; }

        public Undergraduate(string email) : base(email)
        {
        }

        public Undergraduate(string email, int universityId, string dob, string degree, string academicYear) :base(email)
        {
            UniversityId = universityId;
            Dob = dob;
            Degree = degree;
            AcademicYear = academicYear;
        }

        public Undergraduate(string email, string name) : base(email, name)
        {
        }

        public Undergraduate(string contact_No, string email, string name) : base(contact_No, email, name)
        {
        }


    }
}
