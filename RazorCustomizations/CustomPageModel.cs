using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_web_pages.RazorCustomizations;

public abstract class CustomPageModel : PageModel
{
    public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        if (context.HandlerMethod == null) {
            context.Result = new NotFoundResult();
        }
    }

    protected IActionResult IActionResultExecution(Func<object> action) {
        try
        {
            var result = action.Invoke();

            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
        catch
        {
            return new JsonResult("Unexpected request error")
            {
                StatusCode = 500
            };
        }
    }
    
}
