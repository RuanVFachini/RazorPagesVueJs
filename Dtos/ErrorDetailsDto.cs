namespace RazorPagesVueJs.Dtos
{
    public class ErrorDetailsDto {

        public string? Message {get;set;}
        public string? StackTrace {get;set;}

        public ErrorDetailsDto(string message, string? stackTrace)
        {
            Message = message;
            StackTrace = stackTrace;
        }
    }
}