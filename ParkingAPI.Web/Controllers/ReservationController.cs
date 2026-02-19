using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Application.Reservations.Commands.CreateReservation;

namespace ParkingAPI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}
