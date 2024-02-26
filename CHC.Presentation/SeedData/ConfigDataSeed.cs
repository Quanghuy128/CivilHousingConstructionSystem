using CHC.Domain.Entities;
using CHC.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CHC.Presentation.SeedData
{
    public static class ConfigDataSeed
    {
        public static async Task SeedData(this IServiceCollection services)
        {
            await services.SeedAccountData();
        }

        private static async Task SeedAccountData(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();

            List<Account> Accounts = new List<Account>(new Account[]
            {
                new Account
                {
                    Username = "customer-01",
                    Password = "1",
                    FullName = "Customer 01",
                    Email = "customer1@gmail.com",
                    PhoneNumber = "000000000",
                    Address = "ABC, ABD Street, BDG City, VN",
                    Role = Domain.Enums.RoleType.Customer,
                },
                new Account
                {
                    Username = "customer-02",
                    Password = "1",
                    FullName = "Customer 02",
                    Email = "customer2@gmail.com",
                    PhoneNumber = "000000000",
                    Address = "ABCD, ABD Street, BDG City, VN",
                    Role = Domain.Enums.RoleType.Customer,
                },
                new Account
                {
                    Username = "seller-01",
                    Password = "1",
                    FullName = "Seller 01",
                    Email = "seller1@gmail.com",
                    PhoneNumber = "000000000",
                    Address = "ABCQ, ABD Street, BDG City, VN",
                    Role = Domain.Enums.RoleType.Seller,
                },
                new Account
                {
                    Username = "seller-02",
                    Password = "1",
                    FullName = "Seller 02",
                    Email = "seller2@gmail.com",
                    PhoneNumber = "000000000",
                    Address = "ABCQW, ABD Street, BDG City, VN",
                    Role = Domain.Enums.RoleType.Seller,
                },
            });

            
            await context.Accounts.AddRangeAsync(Accounts);
            await context.SaveChangesAsync();

            }
        }
}
