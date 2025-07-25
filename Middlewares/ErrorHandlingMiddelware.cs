using System.Net;
using System.Text.Json;

namespace ApiCRUDMongoDB.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        this._next = next;
        this._logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        Console.WriteLine("Inside Middleware");
        try
        {
            await _next(httpContext);
        }
        catch (System.Exception Exception)
        {
            _logger.LogError(Exception, "Something wrong happen");
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "applicaction/json";

            var jsonResponse = new
            {
                error = "Internal Server Error.",
                message = Exception
            };

            var json = JsonSerializer.Serialize(jsonResponse);
            await httpContext.Response.WriteAsJsonAsync(json);
        }

    }
}
