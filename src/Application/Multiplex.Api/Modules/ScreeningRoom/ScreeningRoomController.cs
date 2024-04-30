using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Multiplex.Api.Shared;
using Multiplex.Api.Modules.ScreeningRoom.GetAll;
using MediatR;

namespace Multiplex.Api.Modules.ScreeningRoom;

[ApiController]
[Route("/api/screening-rooms")]
public class ScreeningRoomsController : ControllerBase
{
    private readonly ILogger<ScreeningRoomsController> _logger;
    private readonly IMediator _mediator;

    public ScreeningRoomsController(ILogger<ScreeningRoomsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<object>> GetAll([FromQuery] QueryParameters<ScreeningRoomModel> parameters)
    {
        return Ok(_mediator.Send(new GetAllScreeningRoomQuery() { Parameters = parameters }));
    }

    [HttpGet]
    [Route("{screeningRoomId}")]
    public ActionResult<Domain.ScreeningRoom> GetById(Guid screeningRoomId)
    {
        return NotFound();
    }

    [HttpGet]
    [Route("{screeningRoomId}/movies/{movieId}")]
    public ActionResult<Domain.ScreeningRoom> ContainsMovie(Guid screeningRoomId, Guid movieId)
    {
        return NotFound();
    }

    [HttpPost]
    [Route("")]
    public ActionResult<Domain.ScreeningRoom> Create([FromBody] ScreeningRoomModel model)
    {
        return NotFound();
    }

    [HttpPost]
    [Route("{screeningRoomId}/movies/{movieId}")]
    public ActionResult<Domain.ScreeningRoom> AddMovie(Guid screeningRoomId, Guid movieId)
    {
        return NotFound();
    }

    [HttpPut]
    [Route("{screeningRoomId}")]
    public ActionResult<Domain.ScreeningRoom> Update(Guid screeningRoomId, [FromBody] ScreeningRoomModel model)
    {
        return NotFound();
    }

    [HttpDelete]
    [Route("{screeningRoomId}")]
    public ActionResult<Domain.ScreeningRoom> Delete(Guid screeningRoomId)
    {
        return NotFound();
    }

    [HttpDelete]
    [Route("{screeningRoomId}/movies/{movieId}")]
    public ActionResult<Domain.ScreeningRoom> DeleteMovie(Guid screeningRoomId, Guid movieId)
    {
        return NotFound();
    }
}
