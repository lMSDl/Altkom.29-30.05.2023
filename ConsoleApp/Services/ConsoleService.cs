using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class ConsoleService : IOutputService
    {
        private readonly IFontService _fontService;
        public ConsoleService(IFontService fontService)
        {
            Console.WriteLine("ConsoleService");
            _fontService = fontService;
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(_fontService.Render(input));
        }
    }
}
