# Understanding `TryParse`, `BindAsync`, and `Endpoint Filters` in .NET 🚀

## 🔹 TryParse (Safe Type Conversion)
✅ Safely converts a string into another data type (e.g., `int.TryParse`, `double.TryParse`).  
✅ Returns `true` if successful, storing the result in an `out` variable.  
❌ Returns `false` instead of throwing an exception if parsing fails.

### 📌 Example:
```csharp
if (int.TryParse("123", out int number))
{
    Console.WriteLine($"✅ Parsed number: {number}");
}
else
{
    Console.WriteLine("❌ Invalid number!");
}
```

## 🔹 BindAsync (Custom Model Binding in Minimal APIs)
✅ Used in minimal APIs to automatically bind request data to an object.
✅ Reads the request body (HttpContext) and parses it into an object.
✅ Allows custom binding logic (e.g., handling raw text, JSON, or different formats).

### 📌 Example:
```csharp
public record SizeDetails(double Height, double Width)
{
    public static async ValueTask<SizeDetails?> BindAsync(HttpContext httpContext)
    {
        using var reader = new StreamReader(httpContext.Request.Body);
        string? body = await reader.ReadToEndAsync();
        return JsonSerializer.Deserialize<SizeDetails>(body);
    }
}
```
## 🔹 Filters (EndpointFilter)
✅ Middleware-like logic that runs before reaching an endpoint handler.
✅ Can validate requests, modify input/output, enforce authentication, etc.
✅ Works like middleware but is specific to endpoints (instead of the whole app).

### 📌 Example:
```csharp
app.MapPost("/sizes", (SizeDetails size) => $"Received size: {size}")
    .AddEndpointFilter(async (context, next) =>
    {
        var size = context.GetArgument<SizeDetails>(0);
        if (size.Height <= 0 || size.Width <= 0)
        {
            return Results.BadRequest("❌ Height and width must be positive!");
        }
        return await next(context);
    });
```
✅ This prevents negative values from being processed!


🛠️ Summary
✅ TryParse → Simple string-to-type conversion, returns true/false instead of exceptions.
✅ BindAsync → Custom model binding for complex objects in minimal APIs.
✅ Filters → Pre-processing logic before a request reaches the handler (like validation & auth).

📌 Now you have a clear understanding of these essential .NET features! 🚀🔥


