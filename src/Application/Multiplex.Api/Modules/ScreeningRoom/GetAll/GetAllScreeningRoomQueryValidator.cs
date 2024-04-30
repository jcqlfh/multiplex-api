using FluentValidation;
using Multiplex.Api.Modules.ScreeningRoom;
using Multiplex.Api.Shared;
using System.Linq;

namespace Multiplex.Api.Modules.ScreeningRoom.GetAll;

public class GetAllScreeningRoomQueryValidator : AbstractValidator<GetAllScreeningRoomQuery>
{
    public GetAllScreeningRoomQueryValidator()
    {
        System.Console.WriteLine("validator");
        RuleFor(x => x.Parameters).NotNull()
            .DependentRules(() =>
                RuleFor(x => x.Parameters.Model).NotNull()
                    .DependentRules(() => RuleFor(x => x.Parameters.Model.Description).NotNull()))
            ;
    }
}