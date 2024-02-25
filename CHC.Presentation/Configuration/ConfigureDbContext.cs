namespace CHC.Presentation.Configuration
{
    public static class ConfigureDbContext
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            return services.AddDbContext();
        }
    }
}
