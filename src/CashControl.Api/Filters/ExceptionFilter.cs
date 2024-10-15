using CashControl.Communication.Responses;
using CashControl.Exception.BaseExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashControl.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is CashControlBaseException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            var ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseErrorJson(ex.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseErrorJson(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("Unknow error");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
