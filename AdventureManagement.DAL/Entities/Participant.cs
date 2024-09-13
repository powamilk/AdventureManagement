using System;
using System.Collections.Generic;

namespace AdventureManagement.DAL.Entities;

public partial class Participant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ParticipantInteraction> ParticipantInteractions { get; set; } = new List<ParticipantInteraction>();
}
