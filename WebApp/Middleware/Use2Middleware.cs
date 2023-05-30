namespace WebApp.Middleware
{
    public class Use2Middleware 
    {
        private readonly RequestDelegate _next;

        public Use2Middleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("USE 2 IN");
            await _next(context);
            Console.WriteLine("USE 2 OUT");
        }
    }
}
