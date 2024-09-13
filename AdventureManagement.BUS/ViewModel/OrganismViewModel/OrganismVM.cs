using AdventureManagement.BUS.ViewModel.AdventureViewModel;
namespace AdventureManagement.BUS.ViewModel.OrganismViewModel
{
    public class OrganismVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public int AdventureCount { get; set; }
        public List<AdventureVM> Adventures { get; set; }
    }

}
