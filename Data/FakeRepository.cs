using RazorPagesVueJs.Models;
using RazorPagesVueJs.Utils;

namespace RazorPagesVueJs.Data
{
    public class FakeRepository
    {
        public IList<StudantEntity> Records { get; set; } = new List<StudantEntity>() {
            new StudantEntity(1, "John", 88.6f),
            new StudantEntity(2, "Marie", 56.32f),
            new StudantEntity(3, "Anthony", 56.32f)
        };
    }
}