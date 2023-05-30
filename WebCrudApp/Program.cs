using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddSingleton<ICrudService<User>, Services.Bogus.CrudService<User>>();
builder.Services.AddSingleton<ICrudService<User>>(x => new Services.Bogus.CrudService<User>(x.GetService<BaseFaker<User>>(), x.GetService<IConfiguration>().GetValue<int>("UsersCount")));
builder.Services.AddTransient<BaseFaker<User>, UserFaker>();

var app = builder.Build();

app.MapGet("/Users", () => app.Services.GetService<ICrudService<User>>()!.ReadAsync());
app.MapGet("/Users/{id:int}", (int id) => app.Services.GetService<ICrudService<User>>()!.ReadAsync(id));
app.MapDelete("/Users/{id:int}", (int id) => app.Services.GetService<ICrudService<User>>()!.DeleteAsync(id));


app.MapGet("/", () => "Hello World!");





app.Run();
