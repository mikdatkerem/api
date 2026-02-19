namespace ParkingAPI.Domain.Entities;

public class ParkingLot
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid ParkingId { get; private set; }
    public Parking Parking { get; private set; } = default!;

    public string Code { get; private set; } = default!; // A1, B3 gibi

    public bool IsOccupied { get; private set; }

    private ParkingLot() { }

    public ParkingLot(Guid parkingId, string code)
    {
        ParkingId = parkingId;
        Code = code;
    }

    public void SetOccupied(bool value)
    {
        IsOccupied = value;
    }
}
