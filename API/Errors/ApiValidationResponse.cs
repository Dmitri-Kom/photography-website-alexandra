using System.Collections.Generic;

namespace API.Errors
{
    public class ApiValidationResponse : ApiResponse
    {
        public ApiValidationResponse() : base(400)
        {
        }

        public IEnumerable<string> ValidationErrors {get; set;}
    }
}