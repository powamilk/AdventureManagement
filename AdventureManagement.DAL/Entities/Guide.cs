using System;
using System.Collections.Generic;

namespace AdventureManagement.DAL.Entities;

public partial class Guide
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Expertise { get; set; } = null!;

    public int ExperienceYears { get; set; }

    public virtual ICollection<Adventure> Adventures { get; set; } = new List<Adventure>();
}
