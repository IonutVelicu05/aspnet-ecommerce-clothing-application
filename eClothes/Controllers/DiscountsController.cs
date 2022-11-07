using eClothes.Data;
using eClothes.Data.Services;
using eClothes.Models;
using Microsoft.AspNetCore.Mvc;

namespace eClothes.Controllers
{
    public class DiscountsController : Controller
    {
        private readonly IDiscountsService _service;

        public DiscountsController(IDiscountsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //get. Discounts/create
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name, Discount")] Discounts discounts)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(discounts);
                return RedirectToAction(nameof(Index));
            }
            return View(discounts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var discountDetails = await _service.GetByIdAsync(id);
            if (discountDetails == null) return View("NotFound");
            return View(discountDetails);
        }

        //get. Discounts/ Edit
        public async Task<IActionResult> Edit(int id)
        {
            var discount = await _service.GetByIdAsync(id);
            if (discount == null) return View("NotFound");
            return View(discount);
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name, Discount")] Discounts discounts)
        {
            if (!ModelState.IsValid)
            {
                return View(discounts);
            }
            await _service.UpdateAsync(id, discounts);
            return RedirectToAction(nameof(Index));
        }
        //get. Discounts/ Edit
        public async Task<IActionResult> Delete(int id)
        {
            var discount = await _service.GetByIdAsync(id);
            if (discount == null) return View("NotFound");
            return View(discount);
        }

        //post
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discount = await _service.GetByIdAsync(id);
            if (discount == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
