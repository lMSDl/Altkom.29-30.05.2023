var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<object>();


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
