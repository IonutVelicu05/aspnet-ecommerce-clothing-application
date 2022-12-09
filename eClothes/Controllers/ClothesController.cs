using eClothes.Data;
using eClothes.Data.Services;
using eClothes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace eClothes.Controllers
{
    public class ClothesController : Controller
    {
        private readonly IClothesService _service;
        private readonly IDiscountsService _discountsService;

        public ClothesController(IClothesService service, IDiscountsService discountsService)
        {
            _service = service;
            _discountsService = discountsService;
        }

        public async Task<IActionResult> Index()
        {
            //var data = await _service.GetAllAsync();
            var data = await _service.GetAllWithDiscounts();
            return View(data);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(n => n.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 || n.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", data);
        }
        public async Task<IActionResult> IndexBoys()
        {
            //var data = await _service.GetAllAsync(n => n.Gender == "M");
            var data = await _service.GetMaleClothesWithDiscounts();
            return View(data);
        }
        public async Task<IActionResult> IndexGirls()
        {
            //var data = await _service.GetAllAsync(n => n.Gender == "F");
            var data = await _service.GetFemaleClothesWithDiscounts();
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
            var muie = await _discountsService.GetAllAsync();
            /*
            foreach (var discount in muie)
            {
                if(discount.Name == newCloth.mata)
                {
                    newCloth.DiscountId = discount.Id;
                }
            }*/

            await _service.AddNewClothAsync(newCloth);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var clothDetail = await _service.GetClothByIdAsync(id);
            return View(clothDetail);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var clothDetails = await _service.GetByIdAsync(id);
            if(clothDetails == null) { return View("NotFound"); }

            var response = new NewClothesVM()
            {
                Id = clothDetails.Id,
                Name = clothDetails.Name,
                Description = clothDetails.Description,
                ImageURL = clothDetails.ImageURL,
                Price = clothDetails.Price,
                Size = clothDetails.Size,
                ProducerId = clothDetails.ProducerId,
                //ClothesDiscountIds = clothDetails.Clothes_Discounts.Select(n => n.DiscountId).ToList(),
                Gender = clothDetails.Gender,
                Stock = clothDetails.Stock,
                ClothesCategoryId = clothDetails.ClothesCategoryId,
            };

            var clothesDropdownsData = await _service.GetNewClothDropdownsValues();
            ViewBag.ProducerId = new SelectList(clothesDropdownsData.Producers, "Id", "FullName");
            ViewBag.DiscountId = new SelectList(clothesDropdownsData.Discounts, "Id", "Name");
            ViewBag.CategoryId = new SelectList(clothesDropdownsData.Categories, "Id", "Name");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewClothesVM newCloth)
        {
            if(id != newCloth.Id) { return View("NotFound"); }
            if (!ModelState.IsValid)
            {
                var clothesDropdownsData = await _service.GetNewClothDropdownsValues();
                ViewBag.ProducerId = new SelectList(clothesDropdownsData.Producers, "Id", "FullName");
                ViewBag.DiscountId = new SelectList(clothesDropdownsData.Discounts, "Id", "Name");
                ViewBag.CategoryId = new SelectList(clothesDropdownsData.Categories, "Id", "Name");
                return View(newCloth);
            }


            await _service.UpdateClothAsync(newCloth);

            return RedirectToAction("Index");
        }
        //get. Discounts/ Edit
        public async Task<IActionResult> Delete(int id)
        {
            var cloth = await _service.GetByIdAsync(id);
            if (cloth == null) return View("NotFound");
            return View(cloth);
        }

        //post
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cloth = await _service.GetByIdAsync(id);
            if (cloth == null) return View("NotFound");

            await _service.DeleteClothAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
