using Microsoft.AspNetCore.Mvc.Filters;

public class ApiExceptionFilter : ExceptionFilterAttribute
{
    public ApiExceptionFilter()
    {
    }


    public override void OnException(ExceptionContext context)
    {

        HandleException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        //Do stuff with the exception
    }

}
