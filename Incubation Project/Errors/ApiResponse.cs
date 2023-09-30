using System;
namespace Incubation_Project.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
          => statusCode switch
          {
              400 => "A Bad Request, You Have Made",
              401 => "Authorized, You Are Not",
              404 => "Resource was not Found",
              500 => "Errors are the path to the Dark Side",
              _ => null
          };
    }
}
