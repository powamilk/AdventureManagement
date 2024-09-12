using System;
using System.Collections.Generic;

namespace AdventureManagement.API.Entities;

public partial class Organism
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Habitat { get; set; } = null!;
}
