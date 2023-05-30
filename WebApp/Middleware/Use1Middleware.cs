namespace WebApp.Middleware
{
    public class Use1Middleware : IMiddleware
    {
        private readonly ILogger<Use1Middleware> _logger;

        public Use1Middleware(ILogger<Use1Middleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogDebug("USE 1");
            Console.WriteLine("USE 1 IN");
            await next(context);
            Console.WriteLine("USE 1 OUT");
        }
    }
}
