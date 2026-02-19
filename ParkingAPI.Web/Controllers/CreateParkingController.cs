using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Application.Parkings.Commands.CreateParking;

namespace ParkingAPI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParkingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateParkingCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}
