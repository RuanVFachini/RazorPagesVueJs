using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesVueJs.Dtos;

namespace razor_web_pages.RazorCustomizations;

public abstract class CustomPageModel : PageModel
{
    protected readonly ILogger<CustomPageModel> Logger;

    public CustomPageModel(ILogger<CustomPageModel> logger)
    {
        Logger = logger;
    }

    public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        if (context.HandlerMethod == null) {
            context.Result = new NotFoundResult();
        }
    }

    protected IActionResult IActionResultExecution<T>(Func<T> action) where T : ApiResultDto, new() {
        try
        {
            var result = action.Invoke();

            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            Logger.LogError("Unexpected error", e);
            return new JsonResult(new T() {
                Error = new ErrorDetailsDto("Unexpected error", e.StackTrace)
            })
            {
                StatusCode = 500
            };
        }
    }
    
}
