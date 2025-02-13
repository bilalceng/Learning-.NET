using System.Text.Json;
using WebApplication1.di;
using WebApplication1.endpoints;
using WebApplication1.middlewares.ExceptionHandling;
using WebApplication1.models;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseDefaultServiceProvider(
    options =>
    {
        options.ValidateScopes = true;
        options.ValidateOnBuild = true;
        
    });
builder.Services.AddEmailSender();
builder.Services.AddMessageSender();
builder.Services.AddDbRepo();


builder.Services.ConfigureHttpJsonOptions(o => {
    o.SerializerOptions.AllowTrailingCommas = false;
    o.SerializerOptions.PropertyNamingPolicy =
        JsonNamingPolicy.CamelCase;
    o.SerializerOptions.PropertyNameCaseInsensitive = true;
});

var app = builder.Build();

app.UseCustomExceptionHandlingMiddleware();

app.MapGet("/heat/{temperature}", (Temperature temperature) => Results.Ok(temperature));
app.MapProductEndpoints();
app.MapDISampleEndpoints();
app.MapDILifeTimeSampleEndpoints();

app.Run();



