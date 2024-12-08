using System.ComponentModel.DataAnnotations;

namespace ConferenceFrontend.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Workplace { get; set; } = string.Empty;

        [Required]
        public string AcademicTitle { get; set; } = string.Empty;

        [Required]
        public string ContactInfo { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
