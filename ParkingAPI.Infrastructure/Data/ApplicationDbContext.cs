using Microsoft.EntityFrameworkCore;
using ParkingAPI.Application.Interfaces;
using ParkingAPI.Domain.Entities;

namespace ParkingAPI.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    
    public DbSet<Parking> Parkings => Set<Parking>();
    public DbSet<ParkingLot> ParkingLots => Set<ParkingLot>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.FirstName).IsRequired();
            entity.Property(x => x.LastName).IsRequired();
            entity.Property(x => x.PhoneNumber).IsRequired();
        });

        builder.Entity<Reservation>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.User)
                  .WithMany()
                  .HasForeignKey(x => x.UserId);

            entity.HasOne(x => x.ParkingLot)
                  .WithMany()
                  .HasForeignKey(x => x.ParkingLotId);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}