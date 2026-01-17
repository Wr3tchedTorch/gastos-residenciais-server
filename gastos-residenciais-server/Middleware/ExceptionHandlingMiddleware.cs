using System;
using System.Text.Json;
using Domain.Exceptions;

namespace gastos_residenciais_server.Middleware
{   
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogError(e, "Response already started during auth callback.");
                    return;
                }
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                Domain.Exceptions.ArgumentException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                type = httpContext.Response.StatusCode switch
                {
                    400 => "Bad Request",
                    404 => "Not Found",
                    _ => "Internal Server Error"
                },
                status = httpContext.Response.StatusCode,
                error = exception.Message
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
