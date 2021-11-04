using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Svc.FizzBuzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Svc.FizzBuzz.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ApiError error = new ApiError
            {
                Message = "A server error has ocurred.",
                Details = context.Exception.Message
            };

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
