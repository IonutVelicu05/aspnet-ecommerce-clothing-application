using eClothes.Data.Services;
using eClothes.Models;
using Microsoft.AspNetCore.Mvc;

namespace eClothes.Controllers
{
    public class ClothesCategoryController : Controller
    {
        private readonly IClothesCategoryService _service;
        public ClothesCategoryController(IClothesCategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name")] ClothesCategory Category)
        {
            if (!ModelState.IsValid)
            {
                Category.Name = "muie";
                return View(Category);
            }
            await _service.AddAsync(Category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] ClothesCategory Category)
        {
            if (!ModelState.IsValid)
            {
                return View(Category);
            }
            await _service.UpdateAsync(id, Category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
