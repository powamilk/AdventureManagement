using AdventureManagement.API.ViewModel.GuideViewModel;
namespace AdventureManagement.API.ViewModel.AdventureVM
{
    public class AdventureVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public int ParticipantCount { get; set; }
        public GuideVM Guide { get; set; }
    }

}
