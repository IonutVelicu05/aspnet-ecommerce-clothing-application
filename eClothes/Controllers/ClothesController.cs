using eClothes.Data;
using eClothes.Data.Services;
using eClothes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eClothes.Controllers
{
    public class ClothesController : Controller
    {
        private readonly IClothesService _service;

        public ClothesController(IClothesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public async Task<IActionResult> IndexBoys()
        {
            var data = await _service.GetAllAsync(n => n.Gender == "M");
            return View(data);
        }
        public async Task<IActionResult> IndexGirls()
        {
            var data = await _service.GetAllAsync(n => n.Gender == "F");
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            var clothesDropdownsData = await _service.GetNewClothDropdownsValues();
            ViewBag.ProducerId = new SelectList(clothesDropdownsData.Producers, "Id", "FullName");
            ViewBag.DiscountId = new SelectList(clothesDropdownsData.Discounts, "Id", "Name");
            ViewBag.CategoryId = new SelectList(clothesDropdownsData.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewClothesVM newCloth)
        {
            if (!ModelState.IsValid)
            {
                var clothesDropdownsData = await _service.GetNewClothDropdownsValues();
                ViewBag.ProducerId = new SelectList(clothesDropdownsData.Producers, "Id", "FullName");
                ViewBag.DiscountId = new SelectList(clothesDropdownsData.Discounts, "Id", "Name");
                ViewBag.CategoryId = new SelectList(clothesDropdownsData.Categories, "Id", "Name");
                return View(newCloth);
            }
            

            await _service.AddNewClothAsync(newCloth);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var clothDetail = await _service.GetClothByIdAsync(id);
            return View(clothDetail);
        }
    }
}
