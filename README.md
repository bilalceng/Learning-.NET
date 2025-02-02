Here’s a **minimal and clean version** of parameter binding rules in **ASP.NET Core Minimal APIs**, with concise examples and emojis for better readability. Perfect for a README! 🚀

---

# 📖 Parameter Binding in Minimal APIs

ASP.NET Core Minimal APIs automatically bind request data to route handler parameters. Here's how it works:

---

## 🎯 **1. Explicit Binding**
Use attributes like `[FromRoute]`, `[FromQuery]`, or `[FromBody]` to specify the binding source.

```csharp
app.MapGet("/users/{id}", ([FromRoute] int id) => $"User ID: {id}");
```

---

## 🌐 **2. Well-Known Types**
Parameters like `HttpContext`, `HttpRequest`, `Stream`, or `IFormFile` are automatically bound.

```csharp
app.MapPost("/upload", async (IFormFile file) => 
{
    var fileName = file.FileName;
    return Results.Ok($"Uploaded: {fileName}");
});
```

---

## 🔄 **3. BindAsync()**
If the parameter type has a `BindAsync()` method, it’s used for binding.

```csharp
public record CustomModel(string Name)
{
    public static ValueTask<CustomModel?> BindAsync(HttpContext context) 
    {
        var name = context.Request.Query["name"];
        return ValueTask.FromResult(new CustomModel(name!));
    }
}

app.MapGet("/custom", (CustomModel model) => $"Hello, {model.Name}!");
```

---

## 🔢 **4. Simple Types**
For `string` or types with `TryParse()`:
- **a)** Binds to route values if the name matches.
- **b)** Otherwise, binds to the query string.

```csharp
app.MapGet("/product", (string name) => $"Product: {name}");
```

---

## 🧮 **5. Arrays of Simple Types**
Arrays of simple types (e.g., `string[]`, `int[]`) bind to the query string for `GET` requests.

```csharp
app.MapGet("/items", (int[] ids) => $"Item IDs: {string.Join(", ", ids)}");
```

---

## 🛠️ **6. Dependency Injection (DI)**
Services from the DI container are automatically injected.

```csharp
app.MapGet("/service", (IMyService service) => service.GetData());
```

---

## 📦 **7. JSON Body Binding**
For complex types, the request body is deserialized from JSON.

```csharp
app.MapPost("/user", (User user) => $"User: {user.Name}");
```

---

## 🎉 **Summary**
Minimal APIs make parameter binding simple and flexible! Whether it’s from the route, query, body, or DI, it just works. 🛡️✨

---
