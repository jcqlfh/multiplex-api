using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Multiplex.Api.Modules.ScreeningRoom.GetAll;

public class GetAllScreeningRoomQueryHandler : IRequestHandler<GetAllScreeningRoomQuery, object>
{
    private readonly ILogger<GetAllScreeningRoomQueryHandler> _logger;
    private readonly IValidator<GetAllScreeningRoomQuery> _validator;

    public GetAllScreeningRoomQueryHandler(ILogger<GetAllScreeningRoomQueryHandler> logger, IValidator<GetAllScreeningRoomQuery> validator)
    {
        _logger = logger;
        _validator = validator;
    }

    public Task<object> Handle(GetAllScreeningRoomQuery request, CancellationToken cancellationToken)
    {
        var vr = _validator.Validate(request);
        if (vr.IsValid)
            Console.WriteLine("Handle");
        else
            throw new ValidationException(vr.Errors.Select(e => new ValidationFailure(
                e.PropertyName,
                e.ErrorMessage))
            .ToList());
        return null;
    }
}