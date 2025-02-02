using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;

namespace WebApplication1.endpoints;

public static class AsParametersEndpoints
{

    public static void MapAsParametersEndpoints(this IEndpointRouteBuilder app)
    {
        
          /*
          app.MapGet("/category/{id}",
         
                    (
                    int id,
                    int page,
                    [FromQuery(Name = "q")]
                    string search,
                    [FromHeader(Name = "sort")]
                    bool? sortAsc
                    ) 
               
                => Results.Ok(id)
        );
         */
          
        app.MapGet("/category/{id}",Search);
    }

    public static async Task<string> Search([AsParameters] SearchModel model)
    {
        return $"Received {model}";
    }
}

// Request sent: curl -X GET "http://localhost:5161/category/123?id=10&page=2&q=exampleSearch" -H "sort: true"
// Response received: Received SearchModel { id = 123, page = 2, search = exampleSearch, ascSort = True }
