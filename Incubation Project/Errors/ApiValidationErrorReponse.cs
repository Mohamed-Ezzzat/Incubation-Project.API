using System.Collections.Generic;

namespace Incubation_Project.Errors
{
    public class ApiValidationErrorReponse:ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ApiValidationErrorReponse() : base(400)
        {

        }
    }
}
