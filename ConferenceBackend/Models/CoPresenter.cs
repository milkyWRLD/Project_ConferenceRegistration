namespace ConferenceBackend.Models
{
    public class CoPresenter
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int PresentationId { get; set; } // Связь с докладом
    }
}
