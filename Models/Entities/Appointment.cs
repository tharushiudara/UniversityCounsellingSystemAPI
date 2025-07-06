namespace UniversityCounsellingSystemAPI.Models.Entities
{
    public class Appointment
    {
        public int universityId;
        private string date;
        private string time;
        private string venue;
        private string counselling_preference;

        public int UniversityId { get => universityId; set
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
        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public string Venue { get => venue; set => venue = value; }
        public string Counselling_preference { get => counselling_preference; set => counselling_preference = value; }

        public Appointment(int university_ID, string date, string time, string venue, string counselling_preference)
        {
            UniversityId = universityId;
            Date = date;
            Time = time;
            Venue = venue;
            Counselling_preference = counselling_preference;
        }

        public Appointment()
        {
        }


    }
}
