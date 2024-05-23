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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer(
                "Server=db-mssql16;Database=2019SBD;Trusted_Connection=True;User Id=sXXXXX;Password=ToNieJestZadneHaslo;")
            .LogTo(Console.WriteLine, LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Clients_pk");
            entity.ToTable("Clients", "trip");
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Pesel).IsRequired();

        });
        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Trips_pk");
            entity.ToTable("Trips", "trip");
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.DateFrom).IsRequired().HasColumnType("datetime");
            entity.Property(e => e.DateTo).IsRequired().HasColumnType("datetime");
        });
        modelBuilder.Entity<ClientTrip>(entity =>
        {
            entity.HasKey(e => new { e.ClientId, e.TripId }).HasName("ClientTrip_pk");
            entity.ToTable("ClientTrips", "trip");
            entity.Property(e => e.RegisteredAt).HasColumnType("datetime");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.HasOne(e => e.Client)
                .WithMany(d => d.ClientTrips)
                .HasForeignKey(e => e.ClientId)
                .HasConstraintName("FK_ClientTrips_Clients");
            entity.HasOne(e => e.Trip)
                .WithMany(d => d.ClientTrips)
                .HasForeignKey(e => e.TripId)
                .HasConstraintName("FK_ClientTrips_Trips");
        });

    }
}
