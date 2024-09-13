namespace AdventureManagement.BUS.ViewModel.Participant
{
    public class ParticipantVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
        public int AdventureCount { get; set; }
    }
}
