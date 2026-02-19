using MediatR;
using ParkingAPI.Application.Interfaces;
using ParkingAPI.Domain.Entities;

namespace ParkingAPI.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User(
            request.IdentityUserId,
            request.FirstName,
            request.LastName,
            request.PhoneNumber
        );

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
