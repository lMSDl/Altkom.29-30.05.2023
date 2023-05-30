var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Use(async (context, next) =>
{
    Console.WriteLine(context.GetEndpoint()?.DisplayName ?? "NULL");
    await next();
});

app.UseRouting();

app.Map("/bye", byeApp =>
{
    byeApp.Use(async (context, next) =>
    {
        Console.WriteLine(context.GetEndpoint()?.DisplayName ?? "NULL");
        await next();
    });

    byeApp.UseRouting();

    byeApp.UseEndpoints(endpoint =>
    {
        endpoint.MapGet("/bye", () => "bye World!");
    });
});

app.Use(async (context, next) =>
{
    Console.WriteLine(context.GetEndpoint()?.DisplayName ?? "NULL");
    await next();
});

app.MapGet("/", () => "Hello World!");

app.MapGet("/hello", () => "Hello World!");

/*app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/hello", () => "Hello World!");

    endpoint.MapGet("/hello2", () => "Hello World!");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Are you lost?");
});*/

app.Run();
