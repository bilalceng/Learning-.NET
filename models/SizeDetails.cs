namespace WebApplication1.models;

public record SizeDetails(double height, double width)
{
    public static async ValueTask<SizeDetails?> BindAsync(HttpContext httpContext)
    {
        using var sr = new StreamReader(httpContext.Request.Body);
        
        string? line1 = await sr.ReadLineAsync(httpContext.RequestAborted);

        if (line1 == null)
        {
            return null;
        }
        
        string? line2 = await sr.ReadLineAsync(httpContext.RequestAborted);

        if (line2 == null)
        {
            return null;
        }
        
        return double.TryParse(line1, out double heigth) && double.TryParse(line2, out double width) ? new SizeDetails(heigth, width) : null;
    }
};

/*
 Request sent: curl -X POST http://localhost:5000/sizes \
     -H "Content-Type: text/plain" \
     --data-binary "12.5 20.8"


 Response received: Received size from the client SizeDetails { height = 12.5, width = 20.8 }
 */


