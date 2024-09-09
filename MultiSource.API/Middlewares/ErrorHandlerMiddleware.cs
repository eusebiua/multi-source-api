namespace MultiSource.API.Middlewares;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger _logger;

    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status500InternalServerError;

            string result = "There was an unexpected error, please contact an administrator at contact@admin.com";
            await response.WriteAsync(result);
        }
    }
}