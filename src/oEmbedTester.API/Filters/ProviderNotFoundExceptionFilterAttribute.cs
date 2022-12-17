using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using oEmbedTester.Domain.Exceptions;

namespace oEmbedTester.Filters;

public class ProviderNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is not ProviderNotFoundException) return;
       
        var result = new ObjectResult(new
        {
            context.Exception.Message, // Or a different generic message
            context.Exception.Source,
            ExceptionType = context.Exception.GetType().FullName,
        })
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        };
        
        // Set the result
        context.Result = result;
    }
}