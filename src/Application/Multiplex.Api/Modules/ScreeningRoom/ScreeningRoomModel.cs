using System;

namespace Multiplex.Api.Modules.ScreeningRoom;

public record ScreeningRoomModel
{
    public int? Number { get; set; }
    public string? Description { get; set; }
}