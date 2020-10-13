using ContactFormAPI.Repositories.Exceptions;
using ContactFormAPI.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace ContactFormAPI
{
    public class CustomExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is MessageNotFoundException messageNotFoundException)
            {
                context.Result = new ObjectResult(messageNotFoundException)
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Value = messageNotFoundException.Message
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is InvalidMessageStateException invalidMessageStateException)
            {
                context.Result = new ObjectResult(invalidMessageStateException)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Value = invalidMessageStateException.Message
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is SmtpClientException smtpClientException)
            {
                context.Result = new ObjectResult(smtpClientException)
                {
                    StatusCode = (int)HttpStatusCode.BadGateway,
                    Value = smtpClientException.Message
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is SendEmailException sendEmailException)
            {
                context.Result = new ObjectResult(sendEmailException)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Value = sendEmailException.Message
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception exception)
            {
                context.Result = new ObjectResult(exception)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Value = "Internal error"
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
