using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string messege = null)
        {
            StatusCode = statusCode;
            Messege = messege ?? GetDefaultMessageForStatusCode();
        }

        public int StatusCode {get; set; }
        public string Messege {get; set; }

        private string GetDefaultMessageForStatusCode()
        {
            return StatusCode switch
            {
                 400 => "You've made a bad request",
                 401 => "You are not authorized",
                 404 => "Resource is not found",
                 500 => "Internal server error has been encountered",
                 _ => null
            };
        }
    }
}