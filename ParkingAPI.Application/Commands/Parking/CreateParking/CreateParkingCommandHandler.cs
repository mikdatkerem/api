using MediatR;
using ParkingAPI.Application.Interfaces;
using ParkingAPI.Domain.Entities;

namespace ParkingAPI.Application.Parkings.Commands.CreateParking;

public class CreateParkingCommandHandler 
    : IRequestHandler<CreateParkingCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateParkingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateParkingCommand request, CancellationToken cancellationToken)
    {
        var parking = new Parking(
            request.Name,
            request.City,
            request.Latitude,
            request.Longitude,
            request.Capacity
        );

        _context.Parkings.Add(parking);
        await _context.SaveChangesAsync(cancellationToken);

        return parking.Id;
    }
}
