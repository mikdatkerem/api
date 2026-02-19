using Microsoft.EntityFrameworkCore;
using ParkingAPI.Domain.Entities;

namespace ParkingAPI.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<Parking> Parkings { get; }
    DbSet<ParkingLot> ParkingLots { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}