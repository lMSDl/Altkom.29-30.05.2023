using ConsoleApp.Configurations.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class RandomFontConsoleService : ConsoleService
    {
        public RandomFontConsoleService(IEnumerable<IFontService> fontServices, Greetings greetings) : base(GetFontService(fontServices))
        {
            Console.WriteLine($"{greetings.Value} from {greetings.Targets.From} to {greetings.Targets.To}");
        }
        /*public RandomFontConsoleService(IEnumerable<IFontService> fontServices, IConfiguration configuration) : base(GetFontService(fontServices))
        {
            var greetings = configuration.GetSection(nameof(Greetings)).Get<Greetings>();
            Console.WriteLine($"{greetings.Value} from {greetings.Targets.From} to {greetings.Targets.To}");
        }*/

        /*public RandomFontConsoleService(IServiceProvider provider) : base(GetFontService(provider.GetServices<IFontService>()))
        {
        }*/

        private static IFontService GetFontService(IEnumerable<IFontService> fontServices)
        {
            Thread.Sleep(1000);
            var value = new Random(DateTime.Now.Second).Next(0, fontServices.Count());
            
            return fontServices.Skip(value).First();
        }
    }
}
