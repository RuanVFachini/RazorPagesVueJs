namespace RazorPagesVueJs.Dtos
{
    public abstract class ApiResultDto
    {
        public bool Success => Error == null;

        public ErrorDetailsDto? Error {get;set;} = null;

        public ApiResultDto(){}

        public ApiResultDto(string message, Exception e)
        {
            Error = new ErrorDetailsDto(message, e.StackTrace); 
        }
    }

    public class ApiListResultDto<T> : ApiResultDto
    {
        public IList<T>? Items { get; set; }

        public int Total {get;set;}

        public ApiListResultDto(){}

        public ApiListResultDto(IList<T>? items, int total)
        {
            Items = items;
            Total = total;
        }

        public ApiListResultDto(string message, Exception e) 
            : base (message, e) {}
    }

    public class ApiSingleResultDto<T> : ApiResultDto
    {
        public T? Item { get; set; }

        public ApiSingleResultDto(){}

        public ApiSingleResultDto(T? item)
        {
            Item = item;
        }

        public ApiSingleResultDto(string message, Exception e) 
            : base (message, e) {}
    }
}