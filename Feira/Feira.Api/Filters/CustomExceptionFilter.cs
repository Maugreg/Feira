﻿using Feira.Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;

namespace Feira.Api.Filters
{
    [ExcludeFromCodeCoverage]
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;

        public CustomExceptionFilter(ILogger logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            if (_logger.IsEnabled(LogEventLevel.Error))
            {
                _logger.Error(context.Exception, $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path.Value} - {context.Exception.Message}");
            }

            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var problemDetails = new ValidationProblemDetails()
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Consulte a propriedade de erros para obter detalhes adicionais."
                };

                if (context.Exception.InnerException != null)
                {
                    string[] mylist = ((FluentValidation.ValidationException)context.Exception.InnerException).Errors.Select(I => Convert.ToString(I.ErrorMessage)).ToArray();
                    problemDetails.Errors.Add("BusinessException", mylist);
                }
                else
                {
                    string[] mylist = ((BusinessException)context.Exception).ValidationError?.Select(I => Convert.ToString(I.Message)).ToArray();
                    
                    if (mylist == null)
                        mylist = new string[] { context.Exception.Message };

                    problemDetails.Errors.Add("BusinessException", mylist);
                }

                _logger.Error(context.Exception, $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path.Value} - {problemDetails}");

                context.Result = new BadRequestObjectResult(problemDetails);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "Ocorreu um erro durante o procedimento." }
                };

                if (_env.IsDevelopment())
                {
                    json.DeveloperMessage = context.Exception.Message;
                }

                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }

            public object DeveloperMessage { get; set; }
        }
    }


    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
