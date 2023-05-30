namespace WebApp.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static void Use2(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Use2Middleware>();
        }

        public static void MapRun(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<MapRunMiddleware>();
        }
    }
}
