using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eClothes.Data;
using eClothes.Models;

namespace eClothes.Controllers
{
    public class testController : Controller
    {
        private readonly AppDbContext _context;

        public testController(AppDbContext context)
        {
            _context = context;
        }

        // GET: test
        public async Task<IActionResult> Index()
        {
              return View(await _context.Clothes_Categories.ToListAsync());
        }

        // GET: test/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clothes_Categories == null)
            {
                return NotFound();
            }

            var clothesCategory = await _context.Clothes_Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothesCategory == null)
            {
                return NotFound();
            }

            return View(clothesCategory);
        }

        // GET: test/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ClothesCategory clothesCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothesCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clothesCategory);
        }

        // GET: test/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clothes_Categories == null)
            {
                return NotFound();
            }

            var clothesCategory = await _context.Clothes_Categories.FindAsync(id);
            if (clothesCategory == null)
            {
                return NotFound();
            }
            return View(clothesCategory);
        }

        // POST: test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ClothesCategory clothesCategory)
        {
            if (id != clothesCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothesCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothesCategoryExists(clothesCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clothesCategory);
        }

        // GET: test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clothes_Categories == null)
            {
                return NotFound();
            }

            var clothesCategory = await _context.Clothes_Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothesCategory == null)
            {
                return NotFound();
            }

            return View(clothesCategory);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clothes_Categories == null)
            {
                return Problem("Entity set 'AppDbContext.Clothes_Categories'  is null.");
            }
            var clothesCategory = await _context.Clothes_Categories.FindAsync(id);
            if (clothesCategory != null)
            {
                _context.Clothes_Categories.Remove(clothesCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothesCategoryExists(int id)
        {
          return _context.Clothes_Categories.Any(e => e.Id == id);
        }
    }
}
