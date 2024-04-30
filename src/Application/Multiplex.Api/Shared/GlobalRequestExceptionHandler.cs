using MediatR.Pipeline;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using System.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using FluentValidation.Results;

using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

namespace Multiplex.Api.Shared;
public class GlobalRequestExceptionHandler<TRequest, TResponse, TException>
  : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TResponse : Task
      where TException : ValidationException
{
    private readonly ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> _logger;
    public GlobalRequestExceptionHandler(
       ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> logger)
    {
        _logger = logger;
    }
    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Something went wrong while handling request of type {@requestType}", typeof(TRequest));
        var problemDetails = new HttpValidationProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "ValidationFailure",
            Title = "Validation error",
            Detail = "One or more validation errors has occurred"
        };

        if (exception.Errors is not null)
        {
            problemDetails.Extensions["errors"] = exception.Errors;
        }

        state.SetHandled(problemDetails as TResponse);
        return Task.CompletedTask;
    }
}