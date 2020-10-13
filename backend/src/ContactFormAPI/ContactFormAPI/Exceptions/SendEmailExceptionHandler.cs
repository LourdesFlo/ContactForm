using ContactFormAPI.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ContactFormAPI.Exceptions
{
    public class SendEmailExceptionHandler : BaseHandler
    {
        public override void Handle(ActionExecutedContext context)
        {
            if (context.Exception is SendEmailException sendEmailException)
            {
                context.Result = new ObjectResult(sendEmailException)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Value = sendEmailException.Message
                };
                context.ExceptionHandled = true;
            }
            else
            {
                if(this._next != null)
                {
                    this._next.Handle(context);
                }
            }
        }
    }
}
