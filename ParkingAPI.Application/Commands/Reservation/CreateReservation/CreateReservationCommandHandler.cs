using MediatR;
using ParkingAPI.Application.Interfaces;
using ParkingAPI.Domain.Entities;

namespace ParkingAPI.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandHandler
    : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateReservationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(
        CreateReservationCommand request,
        CancellationToken cancellationToken)
    {
        var reservation = new Reservation(
            request.UserId,
            request.ParkingLotId
        );

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync(cancellationToken);

        return reservation.Id;
    }
}
