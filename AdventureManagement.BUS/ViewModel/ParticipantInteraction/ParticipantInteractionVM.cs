namespace AdventureManagement.BUS.ViewModel.ParticipantInteraction
{
    public class ParticipantInteractionVM
    {
        public int Id { get; set; }
        public int AdventureId { get; set; }
        public string AdventureTitle { get; set; }
        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
