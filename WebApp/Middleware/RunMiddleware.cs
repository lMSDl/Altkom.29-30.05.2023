namespace WebApp.Middleware
{
    public class RunMiddleware 
    {

        public RunMiddleware(RequestDelegate _) {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("RUN");
            await context.Response.WriteAsync("Hello world!");
        }
    }
}
