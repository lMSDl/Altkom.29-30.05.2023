using ConsoleApp;
using ConsoleApp.Configurations;
using ConsoleApp.Configurations.Models;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;


IServiceCollection serviceCollection = new ServiceCollection();

//serviceCollection.AddTransient<ConsoleService>();
/*serviceCollection.AddTransient<IOutputService>(provider =>
{
    if (DateTime.Today < new DateTime(2023, 6, 1))
        return new ConsoleService();
    return new DebugService();
});*/
//transient - zawsze nowa instancja
serviceCollection.AddTransient<IFontService, StandardFontService>();
//singleton - zawsze ta sama instancja
serviceCollection.AddSingleton<IFontService, Larry3dFontService>();
//scoped - instancja tworzona dla każdego nowego scope
serviceCollection.AddScoped<IOutputService, RandomFontConsoleService>();

serviceCollection.AddSingleton<Greetings>(provider => provider.GetService<IConfiguration>()!.GetSection(nameof(Greetings)).Get<Greetings>());
var config = new ConfigurationBuilder().AddJsonFile("Configurations/config.json")
                                                                    .Build();
serviceCollection.AddSingleton<IConfiguration>(provider => config);

serviceCollection.AddLogging(options =>
    options.AddConfiguration(config.GetSection("Logging"))
    //.SetMinimumLevel(LogLevel.Debug)
    .AddConsole()
    .AddDebug()
    .AddEventLog()
);
serviceCollection.AddTransient<LoggerDemo>();

IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


var logger = serviceProvider.GetService<ILogger<Program>>();


logger.LogDebug("debug");
logger.LogError("error");
logger.LogTrace("trace");
logger.LogInformation("information");

serviceProvider.GetService<LoggerDemo>().Work();

Console.ReadLine();


static void dotNet6(string[] args)
{
    //namespace ConsoleApp
    //{
    //    internal class Program
    //    {
    //        static void Main(string[] args)
    //        {

    //Instrukcja najwyższego poziomu


    Console.WriteLine($"Hello, {args[0]}!");
    JsonConvert.SerializeObject(new object());

    string? name = "ALA";
    string result = ToLower(name)!; // ! - uspokaja warningi przy niezgodności typu NULL z nieNULL

    string? ToLower(string? value /*!! - parameter null-checking feature - automatycznie dodaje kod jak poniżej*/)
    {
        /*if(value == null)
            throw new ArgumentNullException("value");*/

        return value?.ToLower();
    }



    //        }
    //    }
    //}
}

static void Configuration()
{
    //Microsoft.Extensions.Configuration
    var configuration = new ConfigurationBuilder()
        //Microsoft.Extensions.Configuration.Json
        .AddJsonFile("Configurations/config.json")
        //Microsoft.Extensions.Configuration.Ini
        .AddIniFile("Configurations/config.ini", optional: false, reloadOnChange: true)
        //Microsoft.Extensions.Configuration.Xml
        .AddXmlFile("Configurations/config.xml", optional: true)
        //NetEscapades.Configuration.Yaml
        .AddYamlFile("Configurations/config.yaml", optional: true)
        .AddEnvironmentVariables()
        //.AddConfiguration(new MyConfigClassImplementingIConfiguration())
        .Build();

    Console.WriteLine(configuration["myvalue"]);

    var greetingsSection = configuration.GetSection("Greetings");
    for (int i = 0; i < configuration.GetValue<int>("Number"); i++)
    {
        Console.WriteLine($"{greetingsSection["Value"]} from {configuration["Greetings:Targets:From"]} to {greetingsSection.GetSection("Targets")["To"]}");
    }

    var greetings = new Greetings();
    greetingsSection.Bind(greetings);

    Console.WriteLine($"{greetings.Value} from {greetings.Targets.From} to {greetings.Targets.To}");

    greetings = configuration.GetSection(nameof(Greetings)).Get<Greetings>();
    Console.WriteLine($"{greetings.Value} from {greetings.Targets.From} to {greetings.Targets.To}");




    for (int i = 0; i < int.Parse(configuration["Number"]); i++)
    {
        Console.WriteLine($"Hello from {configuration["Hello"]}");

        Console.WriteLine($"Hello from {configuration["HelloJson"]}");
        Console.WriteLine($"Hello from {configuration["HelloYaml"]}");
        Console.WriteLine($"Hello from {configuration["HelloIni"]}");
        Console.WriteLine($"Hello from {configuration["HelloXml"]}");

        Console.ReadLine();
    }
}

static void DependencyInjection(IServiceProvider serviceProvider)
{
    IOutputService? outputService = serviceProvider.GetService<IOutputService>();
    //outputService = serviceProvider.GetRequiredService<IOutputService>();
    outputService?.WriteLine("ala ma kota");

    using (var scope = serviceProvider.CreateScope())
    {

        var outputServices = scope.ServiceProvider.GetServices<IOutputService>();
        foreach (var service in outputServices)
        {
            service.WriteLine("ala ma kota");
        }

    }

    using (var scope = serviceProvider.CreateScope())
    {
        outputService = scope.ServiceProvider.GetService<IOutputService>();
        outputService?.WriteLine("ala ma kota");
    }
}