using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using System.Diagnostics;

namespace Core.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        try
        {
            string message = "[Request]  HTTP "
                + context.Request.Method + " - "
                + context.Request.Path;

            await _next(context);
            watch.Stop();

            message = "[Response] HTTP "
                + context.Request.Method + " - "
                + context.Request.Path + " responded "
                + context.Response.StatusCode + " in "
                + watch.Elapsed.TotalMilliseconds + " ms";

            _logger.LogInformation(message);
        }
        catch (Exception exception)
        {
            watch.Stop();
            await HandleExceptionAsync(context, exception, watch);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception, Stopwatch watch)
    {
        string message = "[Error]  HTTP "
            + context.Request.Method + " - "
            + context.Response.StatusCode
            + " Error Message " + exception.Message
            + " in " + watch.Elapsed.TotalMilliseconds + " ms";

        _logger.LogInformation(message);

        var errorDetails = new ErrorDetails
        {
            StatusCode = (int)HttpStatusCode.BadRequest,
            Errors = exception.Message,
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var json = JsonSerializer.Serialize(errorDetails);

        return context.Response.WriteAsync(json);
    }
}

public static class ExceptionHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Errors { get; set; }
}
