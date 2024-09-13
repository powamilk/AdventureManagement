namespace AdventureManagement.BUS.ViewModel.AdventureViewModel
{
    public class UpdateAdventureVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public int GuideId { get; set; }
        public List<int> OrganismIds { get; set; }
    }

}
