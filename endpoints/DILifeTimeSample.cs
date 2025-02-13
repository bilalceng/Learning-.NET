using WebApplication1.models;

namespace WebApplication1.endpoints;

public static class DILifeTimeSample
{

     public static void  MapDILifeTimeSampleEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/rowcounts", RowCounts);
    }

    static string RowCounts(DataContext db, Repository repository)
    {
        int dbCount = db.RowCount;
        int repositoryRowCount = repository.getRowCount;
        
        return $"Row db counts: {dbCount}, Row repo count: {repositoryRowCount}";
    }

}