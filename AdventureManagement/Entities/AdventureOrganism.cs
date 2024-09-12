namespace AdventureManagement.API.Entities
{
    public class AdventureOrganism
    {
        public int Id { get; set; }
        public int AdventureId { get; set; }
        public int OrganismId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Adventure Adventure { get; set; } = null!;
        public virtual Organism Organism { get; set; } = null!;
    }
}
