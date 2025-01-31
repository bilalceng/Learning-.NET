using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;

namespace WebApplication1.endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/product",PostProduct);
        // app.MapGet("/product", ErrProduct);
        app.MapGet("/product/search", GetId);
        app.MapGet("/products", GetHeaderValues);
        app.MapGet("/temperatures", GetTemperatures);
        
    }

    public static async Task<IResult> PostProduct(Product product)
    {
        return Results.Created($"/product/{product.Id}", product);
    }

    public static async Task<IResult> ErrProduct([FromBody] Product product)
    {
        return Results.Created($"/product/{product.Id}", product);
    }

    public static  string GetId([FromQuery(Name = "id")] int[] ids)
    {
        return $"Received  id:  {ids.Length}";
    }

    public static async Task<IResult> GetHeaderValues([FromHeader(Name = "X-Product-Id")] int[] productIds)
    {
        return Results.Ok(productIds);
    }

    public static async Task<IResult> GetTemperatures([FromHeader(Name = "X-Temperature")] string[] temperatures)
    {
        List<Temperature> temperaturesArray = new List<Temperature>();

        foreach (var temperature in  temperatures)
        {
            if (Temperature.TryParse(temperature, out Temperature temp))
            {
                temperaturesArray.Add(temp);
            }
            else
            {
                return Results.BadRequest("Invalid temperature");
            }
        }

        return Results.Ok(temperaturesArray);
    } 
}