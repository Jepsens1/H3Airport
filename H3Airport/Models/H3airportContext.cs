using Microsoft.EntityFrameworkCore;

namespace H3Airport.Models;

public partial class H3airportContext : DbContext
{
    public H3airportContext()
    {
    }
    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-51IFUJ0\\SQLEXPRESS;Database=H3Airport;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Airlines__3213E83FF715EA62");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.IataCode).HasName("PK__Airports__1B78975D7815EC34");

            entity.Property(e => e.IataCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("iata_code");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Flights__3213E83FBAE8AE96");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AirlineId).HasColumnName("airline_id");
            entity.Property(e => e.ArrivalTime)
                .HasColumnType("datetime")
                .HasColumnName("arrival_time");
            entity.Property(e => e.DepartureTime)
                .HasColumnType("datetime")
                .HasColumnName("departure_time");
            entity.Property(e => e.Departurelocation)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("departurelocation");
            entity.Property(e => e.Destination)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("destination");

            entity.HasOne(d => d.Airline).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AirlineId)
                .HasConstraintName("FK__Flights__airline__5629CD9C");

            entity.HasOne(d => d.DeparturelocationNavigation).WithMany(p => p.FlightDeparturelocationNavigations)
                .HasForeignKey(d => d.Departurelocation)
                .HasConstraintName("FK__Flights__departu__571DF1D5");

            entity.HasOne(d => d.DestinationNavigation).WithMany(p => p.FlightDestinationNavigations)
                .HasForeignKey(d => d.Destination)
                .HasConstraintName("FK__Flights__destina__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
