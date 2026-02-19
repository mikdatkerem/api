namespace ParkingAPI.Domain.Entities;

public class Reservation
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid UserId { get; private set; }
    public User User { get; private set; } = default!;

    public Guid ParkingLotId { get; private set; }
    public ParkingLot ParkingLot { get; private set; } = default!;

    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }

    private Reservation() { }

    public Reservation(Guid userId, Guid lotId)
    {
        UserId = userId;
        ParkingLotId = lotId;
        StartTime = DateTime.UtcNow;
    }

    public void Finish()
    {
        EndTime = DateTime.UtcNow;
    }
}
