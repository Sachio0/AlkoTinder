using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedDataAsync(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName="Sachio", UserName = "Sławek", Email = "test@test.com"},
                    new AppUser{DisplayName="trap", UserName = "trap", Email = "trap@test.com"},
                    new AppUser{DisplayName="trap2", UserName = "trap2", Email = "trap2@test.com"}
                };
                foreach (var item in users)
                {
                    await userManager.CreateAsync(item, "Pa$$word1");
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
