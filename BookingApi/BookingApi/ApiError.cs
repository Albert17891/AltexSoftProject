using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingApi
{
    public class ApiError : ProblemDetails
    {
        public const string UnhandledError = "UnhandledException";
        private HttpContext _context;
        private Exception _exception;

        public LogLevel LogLevel { get; set; }
        public string Code { get; set; }
        public string TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                {
                    return (string)traceId;
                }

                return null;
            }
            set => Extensions["TraceId"] = value;
        }

        public ApiError(HttpContext context, Exception exception)
        {
            _context = context;
            _exception = exception;

            TraceId = context.TraceIdentifier;
            Code = "UnhandledErrorCode";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Instance = context.Request.Path;
            Status = Status = (int)HttpStatusCode.InternalServerError;

            //HandleException((dynamic)exception);
        }

    }
}
