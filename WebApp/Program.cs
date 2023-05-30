using WebApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<Use1Middleware>();
builder.Services.AddTransient<MapRunMiddleware>();


var app = builder.Build();


app.UseMiddleware<Use1Middleware>();

app.Map("/map", mapApp =>
{
    if (app.Environment.IsDevelopment())
    {
        mapApp.Use(async (context, next) =>
        {
            Console.WriteLine("MAP USE 1 IN");
            await next();
            Console.WriteLine("MAP USE 1 OUT");
        });
    }

    mapApp.MapRun();
});

app.Use2();

app.MapWhen(context => context.Request.Query.TryGetValue("name", out _), mapWhenApp =>
{
    mapWhenApp.Run(async context =>
    {
        await context.Response.WriteAsync($"Hello {context.Request.Query["name"]}!");
    });

});

app.UseMiddleware<RunMiddleware>();


app.Use(async (context, next) =>
{
    Console.WriteLine("USE 3 IN");
    await next();
    Console.WriteLine("USE 3 OUT");
});


app.Run();