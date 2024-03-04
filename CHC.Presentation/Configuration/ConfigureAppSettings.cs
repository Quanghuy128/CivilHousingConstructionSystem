using Autofac;
using CHC.Domain.Common;

namespace CHC.Presentation.Configuration
{
    public static class ConfigureAppSettings
    {
        public static void SettingsBinding(this IConfiguration configuration)
        {

            AppConfig.ConnectionStrings = new ConnectionStrings();
            AppConfig.Admin = new Admin();

            configuration.Bind("ConnectionStrings", AppConfig.ConnectionStrings);
            configuration.Bind("Admin", AppConfig.Admin);
        }

      
    }
}