using TimetablesProject.Middlewares;

namespace Timetables.Application.Extentions
{
    public static class CustomExceptionHandlerMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomeExceptionHandlerMiddleware>();
        }
    }
}
