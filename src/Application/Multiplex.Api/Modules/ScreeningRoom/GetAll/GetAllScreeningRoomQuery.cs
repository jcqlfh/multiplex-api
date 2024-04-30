using MediatR;
using Multiplex.Api.Modules.ScreeningRoom;
using Multiplex.Api.Shared;

namespace Multiplex.Api.Modules.ScreeningRoom.GetAll;

public record GetAllScreeningRoomQuery : IRequest<object>
{
    public QueryParameters<ScreeningRoomModel> Parameters { get; set; } = new();
}