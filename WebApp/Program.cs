var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<object>();


var app = builder.Build();


app.Use(async (context, next) =>
{
    Console.WriteLine("USE 1 IN");
    await next();
    Console.WriteLine("USE 1 OUT");
});


app.Map("/map", mapApp =>
{
    mapApp.Use(async (context, next) =>
    {
        Console.WriteLine("MAP USE 1 IN");
        await next();
        Console.WriteLine("MAP USE 1 OUT");
    });

    mapApp.Run(async (context) =>
    {
        Console.WriteLine("MAP RUN");
        await context.Response.WriteAsync("Hello FROM MAP!");
    });
});


app.Use(async (context, next) =>
{
    Console.WriteLine("USE 2 IN");
    await next();
    Console.WriteLine("USE 2 OUT");
});

app.MapWhen(context => context.Request.Query.TryGetValue("name", out _), mapWhenApp =>
{
    mapWhenApp.Run(async context =>
    {
        await context.Response.WriteAsync($"Hello {context.Request.Query["name"]}!");
    });

});

app.Run(async (context) =>
{
    Console.WriteLine("RUN");
    await context.Response.WriteAsync("Hello world!");
});


app.Use(async (context, next) =>
{
    Console.WriteLine("USE 3 IN");
    await next();
    Console.WriteLine("USE 3 OUT");
});


app.Run();
