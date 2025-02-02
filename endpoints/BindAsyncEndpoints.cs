using WebApplication1.models;

namespace WebApplication1.endpoints;

public static class BindAsyncEndpoints
{
    public static void MapAsyncEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/sizes", (SizeDetails size) => $"Received size from the client {size}");
    }
}