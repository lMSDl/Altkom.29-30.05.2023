using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class LoggerDemo
    {
        private readonly ILogger<LoggerDemo> _logger;

        public LoggerDemo(ILogger<LoggerDemo> logger)
        {
            _logger = logger;
        }

        public void Work()
        {
            try
            {

                using (var scope1 = _logger.BeginScope("Work"))
                using (var scope2 = _logger.BeginScope("Some format {0}", 12345))
                using (var scope3 = _logger.BeginScope(new Dictionary<string, string> { ["Key"] = "Value", ["Age"] = "15" }))
                {

                    //_logger.LogTrace("Begin Work");

                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            using var scope4 = _logger.BeginScope(i.ToString());
                            _logger.LogDebug("working...");

                            if (i == 5)
                                throw new IndexOutOfRangeException($"Index: {i}");

                            if (i == 9)
                                throw new Exception("Oopss...");
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            _logger.LogError(ex, ex.Message);
                        }
                    }
                    //_logger.LogTrace("End Work");
                }
            }
            catch (Exception e) when (LogError(e))
            {
            }


        }

        private bool LogError(Exception e)
        {
            _logger.LogError(e, e.Message);
            return true;
        }

    }
}
