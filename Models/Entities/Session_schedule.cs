using System.Runtime.InteropServices;

namespace UniversityCounsellingSystemAPI.Models.Entities
{
    public class Session_schedule
    {
        public int session_NO;
        private int universityId;
        private string date;
        private string time;
        private string venue;

        public int Session_NO { get => session_NO; set => session_NO = value; }
        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public string Venue { get => venue; set => venue = value; }
        public int UniversityId { get => universityId; set => universityId = value; }

        public Session_schedule(int session_NO, int university_ID, string date, string time, string venue)
        {
            Session_NO = session_NO;
            UniversityId = UniversityId;
            Date = date;
            Time = time;
            Venue = venue;
        }

        public Session_schedule()
        {
        }

    }
}
