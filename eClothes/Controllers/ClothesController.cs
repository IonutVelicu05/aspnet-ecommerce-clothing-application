using eClothes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eClothes.Controllers
{
    public class ClothesController : Controller
    {
        private readonly AppDbContext _context;

        public ClothesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Clothes.ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> IndexBoys()
        {
            var data = await _context.Clothes.Where(i => i.Gender == "M").ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> IndexGirls()
        {
            var data = await _context.Clothes.Where(i => i.Gender == "F").ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var cloth = await _context.Clothes.FirstOrDefaultAsync(i => i.Id == id);
            if (cloth == null) return View("NotFound");
            return View(cloth);
        }
    }
}
