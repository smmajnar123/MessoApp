using MessoApp.DTO.ResponseModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            int statusCode;
            string errorType;

            switch (exception)
            {
                case UnauthorizedAccessException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errorType = "Unauthorized";
                    break;

                case ArgumentException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorType = "BadRequest";
                    break;

                case KeyNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    errorType = "NotFound";
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    errorType = "ServerError";
                    break;
            }

            var response = new ErrorResponseModel
            {
                StatusCode = statusCode,
                Message = exception.Message,
                ErrorType = errorType
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
