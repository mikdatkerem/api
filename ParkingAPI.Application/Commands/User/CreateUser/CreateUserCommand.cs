using MediatR;

namespace ParkingAPI.Application.Users.Commands.CreateUser;

public record CreateUserCommand(
    string IdentityUserId,
    string FirstName,
    string LastName,
    string PhoneNumber
) : IRequest<Guid>;
