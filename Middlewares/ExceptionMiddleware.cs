using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            var statusCode = ex switch
            {
                KeyNotFoundException => StatusCodes.Status404NotFound,

                InvalidOperationException => StatusCodes.Status400BadRequest,

                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
                Timestamp = DateTime.UtcNow
           
            });
        }
    }

}
