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

        base.OnPageHandlerExecuted(context);
    }
    
}
