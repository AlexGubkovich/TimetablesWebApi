using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace TimetablesProject.Middlewares
{
    public class CustomeExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomeExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Value);
                    break;
                case DbUpdateException dbUpdateException:
                    if(dbUpdateException.InnerException.Message.Contains("UNIQUE constraint")) {
                        code = HttpStatusCode.Conflict;
                        var str = dbUpdateException.InnerException.Message;
                        str = str.Substring(str.IndexOf("UNIQUE"));
                        str = str.Substring(0, str.Length - 2);
                        result = JsonSerializer.Serialize($"Cannot insert duplicate key row in object. {str}");
                    } 
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
