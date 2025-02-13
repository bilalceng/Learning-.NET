# 🚀 Dependency Injection (DI) in ASP.NET Core Minimal APIs

Dependency Injection (DI) is a fundamental concept in ASP.NET Core, enabling loose coupling, testability, and modularity. ASP.NET Core’s DI container provides built-in support for service registration and resolution.

---

## 🏗️ **1. Registering Services**
In **Program.cs**, services are registered in the DI container using `builder.Services.AddXXX()`, following the built-in DI container approach.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMyService, MyService>();
var app = builder.Build();
```

### 💡 Key Takeaway:
- ASP.NET Core **does not support property injection** by default.
- Services should be **registered before `builder.Build()` is called**.

---

## 🎯 **2. Constructor Injection in Minimal APIs**
Minimal APIs resolve services automatically through **constructor injection** when used in route handlers.

```csharp
app.MapGet("/data", (IMyService service) => service.GetData());
```

✅ No need for `[FromServices]`—ASP.NET Core’s built-in DI container automatically injects dependencies.

---

## 🔄 **3. Service Lifetimes Explained**
ASP.NET Core DI supports three service lifetimes:

- **Transient (`AddTransient<T>`)**: A new instance is created every time it’s requested.
- **Scoped (`AddScoped<T>`)**: A single instance is created per HTTP request.
- **Singleton (`AddSingleton<T>`)**: A single instance is created for the app’s lifetime.

```csharp
builder.Services.AddTransient<IMyService, MyService>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSingleton<ILogger, Logger>();
```

### ⚠️ **Beware of Capturing Scoped Services in Singletons!**
If a singleton service depends on a scoped service, it can cause **unexpected behavior**.

```csharp
public class MySingleton
{
    private readonly IRepository _repository;
    public MySingleton(IRepository repository) // ❌ Avoid injecting scoped services
    {
        _repository = repository;
    }
}
```

🔹 Instead, inject `IServiceProvider` and resolve the service inside a method:

```csharp
public class MySingleton
{
    private readonly IServiceProvider _provider;
    public MySingleton(IServiceProvider provider) 
    {
        _provider = provider;
    }
    public void DoWork()
    {
        using var scope = _provider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IRepository>();
        repository.Process();
    }
}
```

---

## 📦 **4. Injecting Configuration with `IOptions<T>`**
Configuration settings can be injected using **Options Pattern (`IOptions<T>`)**.

```csharp
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

app.MapGet("/config", (IOptions<AppSettings> options) =>
{
    return Results.Ok(options.Value);
});
```

---

## 🌐 **5. Injecting `HttpClient` Efficiently**
Instead of manually creating `HttpClient`, register it using `AddHttpClient()`.

```csharp
builder.Services.AddHttpClient<IMyService, MyService>();
```

🔹 This ensures **connection pooling and performance optimization**.

---

## 🏗️ **6. Factory-based Dependency Injection**
You can use factories for **custom service creation**.

```csharp
builder.Services.AddSingleton(provider => new MyService("Custom Param"));
```

---

## 🔄 **7. Injecting Services into Middleware**
Middleware components can use DI via constructor injection.

```csharp
public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMyService _service;
    public CustomMiddleware(RequestDelegate next, IMyService service)
    {
        _next = next;
        _service = service;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        _service.Process();
        await _next(context);
    }
}

app.UseMiddleware<CustomMiddleware>();
```

---

## 🎯 **8. Using DI with Background Services**
To inject services into background tasks, inherit from `BackgroundService`.

```csharp
public class MyBackgroundService : BackgroundService
{
    private readonly IMyService _service;
    public MyBackgroundService(IMyService service)
    {
        _service = service;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _service.DoWork();
            await Task.Delay(5000, stoppingToken);
        }
    }
}
```

Register it using:

```csharp
builder.Services.AddHostedService<MyBackgroundService>();
```

---

## 🎉 **Summary**
- **Minimal APIs automatically inject services into route handlers.**
- **Avoid injecting scoped services into singletons directly.**
- **Use `IOptions<T>` for configuration and `AddHttpClient()` for HTTP clients.**
- **Factory-based DI allows dynamic service creation.**
- **Middleware and Background Services fully support DI.**

🚀 **Mastering DI in ASP.NET Core Minimal APIs makes your app more modular, scalable, and testable!**

# 📖 Parameter Binding in Minimal APIs
