using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Tasman.Shared.Library.Models;

namespace Tasman.Domain.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Result != null)
        {
            return;
        }

        context.Result = new ObjectResult(new ApiResponse<string>(error: "There was an unexpected error with the application. Please contact support!"))
        {
            StatusCode = 500
        };

        Log.Error(""); //TODO: configurar log de erro
    }
}