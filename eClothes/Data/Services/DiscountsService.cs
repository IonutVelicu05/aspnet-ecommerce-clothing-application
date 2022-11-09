using eClothes.Data.Base;
using eClothes.Models;
using Microsoft.EntityFrameworkCore;

namespace eClothes.Data.Services
{
    public class DiscountsService : EntityBaseRepository<Discounts>, IDiscountsService
    {
        public DiscountsService(AppDbContext context) : base(context)
        {
        }
    }
}
