using AdventureManagement.BUS.ViewModel.GuideViewModel;
using AdventureManagement.BUS.ViewModel.OrganismViewModel;
namespace AdventureManagement.BUS.ViewModel.AdventureViewModel
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
