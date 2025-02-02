# Understanding `[AsParameters]` in .NET Minimal APIs 🚀

In .NET Minimal APIs, you can simplify endpoint parameter binding using the `[AsParameters]` attribute. This feature makes your endpoints cleaner and more readable by binding a type’s constructor parameters directly to the request, allowing you to avoid manually handling each parameter in the endpoint handler.

---

## 🔹 What is `[AsParameters]`?

The `[AsParameters]` attribute allows you to bind constructor parameters of a record or class to incoming request values, automatically applying common binding rules. It works similarly to attributes like `[FromQuery]`, `[FromRoute]`, `[FromBody]`, and `[FromHeader]`, but instead of decorating each individual parameter, you decorate the entire type (usually a record or class).

### 📌 Key Features:
- Automatically binds request data (query, route, headers, body) to the constructor parameters of a class or record.
- Simplifies endpoint definitions by removing the need to bind each parameter manually.
- Supports advanced binding features, such as dependency injection for services.

---

## 🔸 Why Use `[AsParameters]`?

When you start adding many parameters to your endpoints, your code can quickly become hard to maintain. By using `[AsParameters]`, you can group all related parameters into a single class or record and let the framework handle the binding. This makes your endpoints more concise and easier to read.

### ✨ Benefits:
- **Cleaner Code**: Reduces the need for multiple binding attributes on each parameter.
- **Improved Readability**: The endpoint logic stays focused, and the constructor of the model handles the parameter bindings.
- **Support for Complex Types**: You can bind entire objects, including primitive types, well-known types, and services.

---

## 🔹 How to Use `[AsParameters]`

1. **Define a Record or Class**: Create a record or class with properties that match the parameters you want to bind.

2. **Apply `[AsParameters]` to Your Endpoint**: Decorate your endpoint handler to accept the record/class as a single parameter, using the `[AsParameters]` attribute.

3. **Binding Logic**: The framework automatically binds the request to the constructor parameters based on common binding rules, such as `[FromRoute]`, `[FromQuery]`, `[FromHeader]`, and `[FromBody]`.

---

### 📌 Example:

Here's an example demonstrating how to use `[AsParameters]` in a Minimal API endpoint:

```csharp
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/category/{id}",
    ([AsParameters] SearchModel model) => $"Received {model}");

app.Run();

record struct SearchModel(
    int id,
    int page,
    [FromHeader(Name = "sort")] bool? sortAsc,
    [FromQuery(Name = "q")] string search);
```

---

### 💡 Explanation:
- The `SearchModel` record holds four parameters: `id`, `page`, `sortAsc`, and `search`.
- **Binding Sources**:
  - `id` is bound from the route parameter (`/category/{id}`).
  - `page` is bound from the query string (`?page=1`).
  - `sortAsc` is bound from a custom header (`sort: true`).
  - `search` is bound from the query string (`?q=exampleSearch`).
- The `SearchModel` is passed as a single parameter to the handler, and `[AsParameters]` tells the framework to handle all the binding automatically.

---

## 🔹 Advanced Usage

You can also inject services or handle body data in your parameters when using `[AsParameters]`. The same binding rules that apply to individual parameters (e.g., `[FromBody]`, `[FromServices]`, etc.) also apply to the constructor of the type.

For example, injecting a service into your parameters:

```csharp
record struct SearchModel(
    int id,
    int page,
    [FromHeader(Name = "sort")] bool? sortAsc,
    [FromQuery(Name = "q")] string search,
    [FromServices] ILogger<SearchModel> logger);
```

In this case, the `ILogger<SearchModel>` service will be automatically injected into the `SearchModel` constructor.

---

## 🔹 Binding Sources

The following binding sources can be applied to the parameters inside the class or record:

- `[FromRoute]`: Binds from the route.
- `[FromQuery]`: Binds from the query string.
- `[FromHeader]`: Binds from the request headers.
- `[FromBody]`: Binds from the request body.
- `[FromServices]`: Binds from the dependency injection container.

---

## 🔹 Summary

- `[AsParameters]` makes endpoint handlers more readable and concise.
- It automates the binding of request data (route, query, header, body) to a class or record's constructor parameters.
- You can mix and match common binding attributes (`[FromRoute]`, `[FromQuery]`, etc.) and even inject services.
- It simplifies your code by reducing the number of explicit binding attributes in the handler.

Now you can focus on writing the business logic in your handler while letting the framework take care of the parameter binding. Happy coding! 🚀
