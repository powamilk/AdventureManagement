using AdventureManagement.API.ViewModel.GuideViewModel;
using AdventureManagement.API.ViewModel.OrganismViewModel;
namespace AdventureManagement.API.ViewModel.AdventureViewModel
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
        public List<OrganismVM> Organisms { get; set; }
    }

}
