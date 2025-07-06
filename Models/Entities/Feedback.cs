namespace UniversityCounsellingSystemAPI.Models.Entities
{
    public class Feedback
    {
        public int universityId;
        private string date;
        private string feedbacks;

        public int UniversityId { get => universityId; set => universityId = value; }
        public string Date { get => date; set => date = value; }
        public string Feedbacks { get => feedbacks; set => feedbacks = value; }

        public Feedback(int university_ID, string date, string feedbacks)
        {
            UniversityId = university_ID;
            Date = date;
            Feedbacks = feedbacks;
        }

        public Feedback()
        {
        }
    }
}
