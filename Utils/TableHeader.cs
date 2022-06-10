namespace RazorPagesVueJs.Utils
{
    public class TableHeader
    {
        public string Title { get; set; }
        public string Name { get; set; }

        public TableHeader(string title, string name)
        {
            this.Title = title;
            this.Name = name;

        }
    }
}