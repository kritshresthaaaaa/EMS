using System.Net;

namespace Employee_Management_System.Application.Common.Model.Error
{
    public class ErrorModel
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }

        public ErrorModel(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
