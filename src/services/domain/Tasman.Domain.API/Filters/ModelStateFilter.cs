using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tasman.Shared.Library.Models;

namespace Tasman.Domain.API.Filters;

public class ModelStateFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.Result != null)
        {
            return;
        }

        if (!context.ModelState.IsValid)
        {
            List<string> errors = new();
            foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry item in context.ModelState.Values)
            {
                foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelError error in item.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            context.Result = new BadRequestObjectResult(new ApiResponse<string>(errors: errors));
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}