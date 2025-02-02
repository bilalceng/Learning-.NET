using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.endpoints;
using WebApplication1.middlewares.ExceptionHandling;
using WebApplication1.models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

builder.Services.ConfigureHttpJsonOptions(o => {
    o.SerializerOptions.AllowTrailingCommas = false;
    o.SerializerOptions.PropertyNamingPolicy =
        JsonNamingPolicy.CamelCase;
    o.SerializerOptions.PropertyNameCaseInsensitive = true;
});

var app = builder.Build();


app.UseCustomExceptionHandlingMiddleware();

app.MapGet("/heat/{temperature}", (Temperature temperature) => Results.Ok(temperature) );

app.MapProductEndpoints();
app.MapAsParametersEndpoints();
app.Run();



