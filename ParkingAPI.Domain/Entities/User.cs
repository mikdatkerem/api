namespace ParkingAPI.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string IdentityUserId { get; private set; } = default!; // ASP.NET Identity bağlantısı

    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string PhoneNumber { get; private set; } = default!;

    public double? Latitude { get; private set; }
    public double? Longitude { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private User() { } // EF Core için

    public User(string identityUserId, string firstName, string lastName, string phoneNumber)
    {
        IdentityUserId = identityUserId;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public void UpdateLocation(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
