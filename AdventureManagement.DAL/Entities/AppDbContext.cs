using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AdventureManagement.DAL.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adventure> Adventures { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Organism> Organisms { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<ParticipantInteraction> ParticipantInteractions { get; set; }

    public virtual DbSet<AdventureOrganism> AdventureOrganisms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=powa;Database=AdventureManagement;Trusted_Connection=True;TrustServerCertificate=True");
}