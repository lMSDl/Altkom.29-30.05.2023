using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class Larry3dFontService : IFontService
    {
        public Larry3dFontService()
        {
            Console.WriteLine("Larry3dFontService");
        }
        public string Render(string input)
        {
            return Figgle.FiggleFonts.Larry3d.Render(input);
        }
    }
}
