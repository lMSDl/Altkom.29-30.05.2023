using ConsoleApp.Configurations.Models;
using Microsoft.Extensions.Configuration;
using System;


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