namespace ConferenceBackend.Models
{
    public class Presentation
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int MainSpeakerId { get; set; } // ID основного докладчика
        public List<int> CoPresentersIds { get; set; } = new List<int>();
    }
}
