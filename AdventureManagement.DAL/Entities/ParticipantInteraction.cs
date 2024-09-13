using System;
using System.Collections.Generic;

namespace AdventureManagement.DAL.Entities;

public partial class ParticipantInteraction
{
    public int Id { get; set; }

    public int AdventureId { get; set; }

    public int ParticipantId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Adventure Adventure { get; set; } = null!;

    public virtual Participant Participant { get; set; } = null!;
}
