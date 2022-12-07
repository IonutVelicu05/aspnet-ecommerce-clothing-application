using eClothes.Data.Static;
using eClothes.Models;
using Microsoft.AspNetCore.Identity;

namespace eClothes.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //discounts
                if (!context.Discounts.Any())
                {
                    context.Discounts.AddRange(new List<Discounts>()
                    {
                        new Discounts()
                        {
                            Name = "Reducere toamna",
                            Discount = 10
                        },
                        new Discounts()
                        {
                            Name = "Reducere iarna",
                            Discount = 15
                        },
                        new Discounts()
                        {
                            Name = "Mega reducere",
                            Discount = 50
                        },
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Dsquared",
                            ProfileBio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Pull n bear",
                            ProfileBio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Vergace",
                            ProfileBio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Bershka",
                            ProfileBio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                /*
                // discount & clothes relation
                if (!context.Clothes_Discounts.Any())
                {
                    context.Clothes_Discounts.AddRange(new List<Clothes_Discounts>()
                    {
                        new Clothes_Discounts()
                        {
                            ClothId = 1,
                            DiscountId = 1,
                        },
                        new Clothes_Discounts()
                        {
                            ClothId = 2,
                            DiscountId = 3,
                        },
                        new Clothes_Discounts()
                        {
                            ClothId = 3,
                            DiscountId = 3,
                        },
                    });
                    context.SaveChanges();
                }*/
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //add roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if(!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                //add users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminEmail = "admin@eclothes.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Fullname = "Ionut Velicu",
                        UserName = "admin-user",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "a856246F$");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                string appUserEmail = "user@eclothes.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        Fullname = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "a856246F$");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
