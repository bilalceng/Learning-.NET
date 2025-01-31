using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication1.middlewares.ExceptionHandling;

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(app =>
        {
            app.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var exception = errorFeature.Error;
                        var errorResponse = new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "An unexpected error occurred.",
                            Detailed = exception, // Include this only in development
                        };
                        
                        var json = JsonSerializer.Serialize(errorResponse);
                        await context.Response.WriteAsync(json);
                    }
                }

            );
        });
        return app;
    }
}