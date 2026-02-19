namespace ParkingAPI.Domain.Entities;

public class Parking
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; } = default!;
    public string City { get; private set; } = default!;

    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

    public int Capacity { get; private set; }

    public ICollection<ParkingLot> Lots { get; private set; } = new List<ParkingLot>();

    private Parking() { }

    public Parking(string name, string city, double lat, double lng, int capacity)
    {
        Name = name;
        City = city;
        Latitude = lat;
        Longitude = lng;
        Capacity = capacity;
    }
}
