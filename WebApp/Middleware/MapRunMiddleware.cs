namespace WebApp.Middleware
{
    public class MapRunMiddleware : IMiddleware
    {
        private readonly ILogger<Use1Middleware> _logger;

        public MapRunMiddleware(ILogger<Use1Middleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate _)
        {
            _logger.LogDebug("MAP RUN");
            Console.WriteLine("MAP RUN");
            await context.Response.WriteAsync("Hello FROM MAP!");
        }
    }
}
