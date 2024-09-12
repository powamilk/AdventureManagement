namespace AdventureManagement.API.ViewModel.AdventureVM
{
    public class CreateAdventureVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public int GuideId { get; set; }
    }

}
