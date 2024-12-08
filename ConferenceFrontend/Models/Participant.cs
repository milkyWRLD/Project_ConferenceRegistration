namespace ConferenceFrontend.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Workplace { get; set; }
        public string AcademicTitle { get; set; }
        public string ContactInfo { get; set; }
        public string Role { get; set; } // Например, "Слушатель" или "Докладчик"
    }
}
