using CHC.Domain.Entities;
using CHC.Domain.Enums;
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

            IList<Account> accounts = null!;
            IList <Material> materials = null!;
            IList<Interior> interiors = null!;

            //Accounts
            if (!context.Accounts.Any()){
                accounts = FileExtension<Account>.LoadJson(path, "ACCOUNT.json");
                await context.Accounts.AddRangeAsync(accounts);
                await context.SaveChangesAsync();
            }

            //Material
            if (!context.Materials.Any())
            {
                materials = FileExtension<Material>.LoadJson(path, "MATERIAL.json");
                await context.Materials.AddRangeAsync(materials);
                await context.SaveChangesAsync();
            }

            //Interior
            if (!context.Interiors.Any())
            {
                interiors = FileExtension<Interior>.LoadJson(path, "INTERIOR.json");
                foreach (var i in interiors)
                {
                    i.StaffId = (await context.Accounts.FirstOrDefaultAsync(x => x.Role == RoleType.Staff))!.Id;
                    i.Staff = (await context.Accounts.FirstOrDefaultAsync(x => x.Role == RoleType.Staff))!;
                    await context.Interiors.AddAsync(i);
                    IList<InteriorDetail> interiorDetails = new List<InteriorDetail>()
                    {
                        new InteriorDetail(){ 
                            InteriorId = i.Id,
                            Interior = i,
                            MaterialId = (await context.Materials.FirstOrDefaultAsync(x => x.Tag.Equals(MaterialTag.Table)))!.Id,
                            Material = (await context.Materials.FirstOrDefaultAsync(x => x.Tag.Equals(MaterialTag.Table)))!,
                            Quantity = 2
                        },
                        new InteriorDetail(){
                            InteriorId = i.Id,
                            Interior = i,
                            MaterialId = (await context.Materials.FirstOrDefaultAsync(x => x.Tag.Equals(MaterialTag.Chair)))!.Id,
                            Material = (await context.Materials.FirstOrDefaultAsync(x => x.Tag.Equals(MaterialTag.Chair)))!,
                            Quantity = 8
                        },
                        new InteriorDetail(){
                            InteriorId = i.Id,
                            Interior = i,
                            MaterialId = (await context.Materials.FirstOrDefaultAsync(x => x.Tag.Equals(MaterialTag.Sofa)))!.Id,
                            Material = (await context.Materials.FirstOrDefaultAsync(x => x.Tag.Equals(MaterialTag.Sofa)))!,
                            Quantity = 2
                        },
                    };
                    await context.InteriorDetails.AddRangeAsync(interiorDetails);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
