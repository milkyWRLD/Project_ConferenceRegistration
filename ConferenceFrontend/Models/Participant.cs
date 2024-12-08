namespace ConferenceFrontend.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Workplace { get; set; } = string.Empty;
        public string AcademicTitle { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public string Role { get; set; } = "Listener";
    }
}
