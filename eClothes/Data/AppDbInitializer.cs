using eClothes.Models;

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
    }
}
