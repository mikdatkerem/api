using MediatR;

namespace ParkingAPI.Application.Parkings.Commands.CreateParking;

public record CreateParkingCommand(
    string Name,
    string City,
    double Latitude,
    double Longitude,
    int Capacity
) : IRequest<Guid>;
