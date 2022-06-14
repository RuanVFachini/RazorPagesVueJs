namespace RazorPagesVueJs.Dtos
{
    public class RequestModelDto
    {
        public int Skip {get;set;} = 0;
        public int MaxResult {get;set;} = 100;

        public string? Sort {get;set;}   
    }
}