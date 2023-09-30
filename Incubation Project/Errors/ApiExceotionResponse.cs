namespace Incubation_Project.Errors
{
    public class ApiExceotionResponse : ApiResponse
    {
        public string Details { get; set; }

        public ApiExceotionResponse(int statusCode, string message = null, string details = null) 
            : base(statusCode, message)
        {
            Details = details;
        }
    }
}
