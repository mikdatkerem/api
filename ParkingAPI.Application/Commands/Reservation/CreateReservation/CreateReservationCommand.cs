using MediatR;

namespace ParkingAPI.Application.Reservations.Commands.CreateReservation;

public record CreateReservationCommand(
    Guid UserId,
    Guid ParkingLotId
) : IRequest<Guid>;
