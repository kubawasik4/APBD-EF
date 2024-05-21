using System.Data.Entity;
using APBD_EF.Models;

namespace APBD_EF.CONTEXT;

using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public Context()
    {
        
    }
    public Context(DbContextOptions<Context> options) : base(options) { }

    public virtual DbSet<Client> Client { get; set; }
    public virtual DbSet<Trip> Trip { get; set; }
    public virtual DbSet<ClientTrip> ClientTrips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Clients_pk");
            entity.ToTable("Clients", "trip");
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Pesel).IsRequired();

        });

    }
}
