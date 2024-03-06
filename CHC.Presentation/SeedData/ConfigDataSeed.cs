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
            string path = "./SeedData/";

            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            if (context.Accounts.Any()) return;

            //Accounts
            IList<Account> accounts = FileExtension<Account>.LoadJson(path, "ACCOUNT.json");
            await context.Accounts.AddRangeAsync(accounts);
            await context.SaveChangesAsync();

            //Interior
            IList<Interior> interiors = FileExtension<Interior>.LoadJson(path, "INTERIOR.json");
            await context.Interiors.AddRangeAsync(interiors);
            await context.SaveChangesAsync();
        }
    }
}
