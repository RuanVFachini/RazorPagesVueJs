using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using razor_web_pages.RazorCustomizations;

namespace razor_web_pages.Pages;

public class AlunosModel : CustomPageModel
{
    private readonly ILogger<AlunosModel> _logger;

    public AlunosModel(ILogger<AlunosModel> logger)
    {
        _logger = logger;
    }

    public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        if (context.HandlerMethod == null) {
            context.Result = new NotFoundResult();
        }

        base.OnPageHandlerExecuted(context);
    }

    public IList<Header> Columns { get; set; } =  new List<Header>() {
            new Header() {
                Title = "Codigo",
                Name = "id"
            },
            new Header() {
                Title = "Nome",
                Name = "name"
            }
        };

    public IList<AlunoEntity> Records  { get; set; } = new List<AlunoEntity>() {
        new AlunoEntity() {
            Id = "1",
            Name = "John"
        }
    };

    public void OnGet()
    {
    }

    public IActionResult OnPostDelete(string id) {
        try {

            var delete = Records.First(x => x.Id == id);
            Records.Remove(delete);

            return new JsonResult(delete) {
                StatusCode = 200
            };
        } catch {
            return new JsonResult("Erro inesperado") {
                StatusCode = 500
            };
        }
    }
    
}

public class AlunoEntity {
    public string? Id {get;set;}
    public string? Name {get;set;}
}

public class Header {
    public string? Title {get;set;}
    public string? Name {get;set;}
}
