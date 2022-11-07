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
                /*
                //producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Bershka",
                            ProfilePictureURL = "https://www.nevada.shopping/sites/nevada.shopping/files/field/operador-logo/bershka_-_logo.jpg",
                            ProfileBio = "This is the description of Bershka"
                        },
                        new Producer()
                        {
                            FullName = "Pull & bear",
                            ProfilePictureURL = "https://freepikpsd.com/file/2019/10/pull-and-bear-png-1.png",
                            ProfileBio = "This is the description of Pull & bear"
                        },
                        new Producer()
                        {
                            FullName = "Zara",
                            ProfilePictureURL = "https://mir-s3-cdn-cf.behance.net/project_modules/2800_opt_1/ee966d75834063.5c5854ad70bf0.jpg",
                            ProfileBio = "This is the description of Zara"
                        },
                        new Producer()
                        {
                            FullName = "Guess",
                            ProfilePictureURL = "https://i.pinimg.com/564x/7b/31/77/7b3177cd6d2552caee1f68650d093e11.jpg",
                            ProfileBio = "This is the description of Guess"
                        },
                        new Producer()
                        {
                            FullName = "Dsqared",
                            ProfilePictureURL = "https://i.pinimg.com/564x/2b/90/26/2b9026f389f99255449b5a5b336743d7.jpg",
                            ProfileBio = "This is the description of the dsquared"
                        },
                    });
                    context.SaveChanges();
                } */
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
                //clothes
                if (!context.Clothes.Any())
                {
                    context.Clothes.AddRange(new List<Clothes>()
                    {
                        new Clothes()
                        {
                            Name = "Tricou dsquared",
                            ImageURL = "https://cdn.aboutstatic.com/file/images/a80d142a56bb55403659c1d5d29df0c2.png?bg=F4F4F5&quality=75&trim=1&height=1067&width=800",
                            Stock = 20,
                            Description = "Un tricou dsquared scump si naspa",
                            Size = "M",
                            Gender = "M",
                            Price = 50,
                            ClothesCategory = Enums.ClothesCategories.Tricou,
                            Producer = "Dsquared",
                        },
                        new Clothes()
                        {
                            Name = "Hanorac frumos",
                            ImageURL = "https://static.pullandbear.net/2/photos//2022/I/0/2/p/8593/902/251/8593902251_2_6_8.jpg?t=1665418708968",
                            Stock = 30,
                            Description = "Un hanorac foarte frumos",
                            Size = "L",
                            Gender = "M",
                            Price = 100,
                            ClothesCategory = Enums.ClothesCategories.Hanorac,
                            Producer = "Pull & bear",
                        },
                        new Clothes()
                        {
                            Name = "Geaca vergace",
                            ImageURL = "https://squareshop.ro/images/stories/virtuemart/product/054060002026_photo1.jpg",
                            Stock = 15,
                            Description = "Geaca de piele de la vergace",
                            Size = "S",
                            Gender = "M",
                            Price = 50,
                            ClothesCategory = Enums.ClothesCategories.Geaca,
                            Producer = "Vergace",
                        },
                        new Clothes()
                        {
                            Name = "Palton femeie",
                            ImageURL = "https://static.bershka.net/4/photos2/2022/I/0/1/p/6968/333/816/796d62f240e390f5a2820143c4f20aaf-6968333816_2_4_0.jpg?",
                            Stock = 6,
                            Description = "Palton de femeie frumos",
                            Size = "L",
                            Gender = "F",
                            Price = 80,
                            ClothesCategory = Enums.ClothesCategories.Palton,
                            Producer = "Bershka",
                        }
                    });
                    context.SaveChanges();
                }
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
                }
            }
        }
    }
}
