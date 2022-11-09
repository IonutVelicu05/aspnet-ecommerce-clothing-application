using eClothes.Data.Base;
using eClothes.Models;

namespace eClothes.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public readonly AppDbContext _context;
        public ProducerService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
