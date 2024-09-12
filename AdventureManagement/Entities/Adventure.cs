namespace AdventureManagement.API.Entities;

public partial class Adventure
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int Duration { get; set; }

    public int? GuideId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Guide? Guide { get; set; }

    public virtual ICollection<ParticipantInteraction> ParticipantInteractions { get; set; } = new List<ParticipantInteraction>();
    public virtual ICollection<AdventureOrganism> AdventureOrganisms { get; set; } = new List<AdventureOrganism>();
}
