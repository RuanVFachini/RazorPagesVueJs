using Microsoft.AspNetCore.Mvc;
using razor_web_pages.RazorCustomizations;
using RazorPagesVueJs.Data;
using RazorPagesVueJs.Dtos;
using RazorPagesVueJs.Extensions;
using RazorPagesVueJs.Models;
using RazorPagesVueJs.Utils;

namespace razor_web_pages.Pages;

public class StudantModel : CustomPageModel
{
    private readonly FakeRepository _fakeRepository;

    public StudantModel(
        ILogger<StudantModel> logger,
        FakeRepository fakeRepository) : base(logger)
    {
        _fakeRepository = fakeRepository;
    }

    public void OnGet()
    {
    }

    public IActionResult OnGetList(RequestModelDto request)
    {
        return IActionResultExecution(() => {
            var query = _fakeRepository.Records.AsQueryable();

            var resultList = query
                .SortAndPage(request)
                .ToList();

            var total = query.Count();

            return new ApiListResultDto<StudantEntity>(resultList, total);
        });
    }

    public IActionResult OnPostDelete(int? id)
    {
        return IActionResultExecution(() => {
            var delete = _fakeRepository.Records.First(x => x.Id == id);
            _fakeRepository.Records.Remove(delete);
            return new ApiSingleResultDto<StudantEntity>(delete);
        });
    }

    public IActionResult OnPostCreate(StudantEntity studant)
    {
        if (!studant.Id.HasValue) {
            studant.Id = (_fakeRepository.Records.Max(x => x.Id) ?? 0) + 1;
        }

        return IActionResultExecution(() => {
            _fakeRepository.Records.Add(studant);
            return new ApiSingleResultDto<StudantEntity>(studant);
        });
    }

    public IActionResult OnPostUpdate(int? id, StudantEntity studant)
    {
        return IActionResultExecution(() => {
            var toUpdate = _fakeRepository.Records.First(x => x.Id == id);
            toUpdate.AverageScore = studant.AverageScore;
            toUpdate.Name = studant.Name;
            return new ApiSingleResultDto<StudantEntity>(toUpdate);
        });
    }
}
