using System.ComponentModel.DataAnnotations;
using WebApplication1.models;

namespace WebApplication1.endpoints;

public static class DataAnnotationEndpoints
{
    public static  void MapDataAnnotationEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/users", saveUser).WithParameterValidation();
        app.MapPost("/user/{id}", ([AsParameters] GetUserModel user) => $"user/{user.Id}" ).WithParameterValidation();
    }

    public static string saveUser(UserModel user)
    {
        return user.ToString();
    }
    
}

struct GetUserModel
{
    [Range(1,10)]
    public int Id { get; set; }
}