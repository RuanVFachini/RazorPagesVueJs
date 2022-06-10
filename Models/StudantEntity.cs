namespace RazorPagesVueJs.Models
{
    public class StudantEntity
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public float? AverageScore { get; set; }

        public StudantEntity()
        {
        }

        public StudantEntity(int? id, string? name, float? averageScore)
        {
            this.Id = id;
            this.Name = name;
            this.AverageScore = averageScore;

        }
    }
}