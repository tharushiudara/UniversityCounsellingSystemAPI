namespace UniversityCounsellingSystemAPI.Models.Entities
{
    public class Progress_tracking
    {
        public int universityId;
        private string lastSessionDate;
        private string progress;
        private string action;
        private string setReminder;

        public int UniversityId { get => universityId; set => universityId = value; }
        public string LastSessionDate { get => lastSessionDate; set => lastSessionDate = value; }
        public string Progress { get => progress; set => progress = value; }
        public string Action { get => action; set => action = value; }
        public string SetReminder { get => setReminder; set => setReminder = value; }

        public Progress_tracking(int universityId, string lastSessionDate, string progress, string action, string setReminder)
        {
            UniversityId = universityId;
            LastSessionDate = lastSessionDate;
            Progress = progress;
            Action = action;
            SetReminder = setReminder;
        }

        public Progress_tracking()
        {
        }
    }
}
