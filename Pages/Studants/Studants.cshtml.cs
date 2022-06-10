using Microsoft.AspNetCore.Mvc;
using razor_web_pages.RazorCustomizations;
using RazorPagesVueJs.Data;
using RazorPagesVueJs.Models;
using RazorPagesVueJs.Utils;

namespace razor_web_pages.Pages;

public class StudantModel : CustomPageModel
{
    private readonly ILogger<StudantModel> _logger;
    private readonly FakeRepository _fakeRepository;

    public StudantModel(
        ILogger<StudantModel> logger,
        FakeRepository fakeRepository)
    {
        _logger = logger;
        _fakeRepository = fakeRepository;
    }

    public void OnGet()
    {
    }

    public IActionResult OnGetList(RequestModel request)
    {
        return IActionResultExecution(() => {
            return _fakeRepository.Records
                .Skip(request.Skip)
                .Take(request.MaxResult)
                .ToList();
        });
    }

    public IActionResult OnPostDelete(int? id)
    {
        return IActionResultExecution(() => {
            var delete = _fakeRepository.Records.First(x => x.Id == id);
            _fakeRepository.Records.Remove(delete);
            return delete;
        });
    }

    public IActionResult OnPostCreate(StudantEntity studant)
    {
        if (!studant.Id.HasValue) {
            studant.Id = (_fakeRepository.Records.Max(x => x.Id) ?? 0) + 1;
        }

        return IActionResultExecution(() => {
            _fakeRepository.Records.Add(studant);
            return studant;
        });
    }

    public IActionResult OnPostUpdate(int? id, StudantEntity studant)
    {
        return IActionResultExecution(() => {
            var toUpdate = _fakeRepository.Records.First(x => x.Id == id);
            toUpdate.AverageScore = studant.AverageScore;
            toUpdate.Name = studant.Name;
            return toUpdate;
        });
    }
}
