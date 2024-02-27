using Microsoft.AspNetCore.Identity;
using System;
using static TheLaptopStore.Areas.Identity.Pages.Account.RegisterModel;

namespace TheLaptopStore.Data {
    public class DbSeeder {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service) {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // creating admin

            var user = new ApplicationUser {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                PersonalID = "111111111",
                City = "Beer",
                StreetName= "Bazel",
                BuildingNumber = 1,
                ApartmentNumber = 1,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb is null) {
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }
    }
}
