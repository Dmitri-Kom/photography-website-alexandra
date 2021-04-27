namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string messege = null, string stackTrace = null) : base(statusCode, messege)
        {
            StackTrace = stackTrace;
        }

        public string StackTrace { get; set; }
    }
}