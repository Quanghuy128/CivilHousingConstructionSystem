using CHC.Domain.Entities;
using CHC.Infrastructure;
using CHC.Presentation.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CHC.Presentation.SeedData
{
    public static class ConfigDataSeed
    {
        public static async Task SeedData(this IServiceCollection services)
        {
            await services.SeedAccountData();
            await services.SeedMaterialData();

        }

        private static async Task SeedAccountData(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            if (context.Accounts.Any()) return;

            IList<Account> accounts = FileExtension<Account>.LoadJson("./SeedData/", "ACCOUNT.json");

            await context.Accounts.AddRangeAsync(accounts);
            await context.SaveChangesAsync();
            }
        private static async Task SeedMaterialData(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            if (context.Materials.Any()) return;

            IList<Material> materials = FileExtension<Material>.LoadJson("./SeedData/", "MATERIAL.json");

            await context.Materials.AddRangeAsync(materials);
            await context.SaveChangesAsync();
        }
    }
}
