using Microsoft.AspNetCore.Identity;

namespace Bumbo.Domain
{
    public static class UserAndRoleSeeder
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Medewerker").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Medewerker";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Manager").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Manager";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Systeembeheerder").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Systeembeheerder";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("Medewerker1").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "SysteemBeheerder";
                user.Email = "systeemBeheerder@bumbo.site";
                user.PhoneNumber = "+31636330098";

                IdentityResult result = userManager.CreateAsync(user, "Welkom123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Systeembeheerder").Wait();
                }
            }

            if (userManager.FindByNameAsync("Medewerker2").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "LaserYesil";
                user.Email = "laser.yesil@bumbo.site";
                user.PhoneNumber = "+31648652286";

                IdentityResult result = userManager.CreateAsync(user, "Welkom123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }

            if (userManager.FindByNameAsync("Medewerker3").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "JobVanKoeveringe";
                user.Email = "job.van.koeveringe@bumbo.site";
                user.PhoneNumber = "+31612852165";

                IdentityResult result = userManager.CreateAsync(user, "Welkom123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Medewerker").Wait();
                }
            }
        }
    }
}
