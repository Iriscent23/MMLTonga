using Microsoft.AspNetCore.Mvc;
using MMLTonga.Data;
using Microsoft.EntityFrameworkCore;
using MMLTonga.Models;

namespace MMLTonga.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DbProductContext _context;

        public ProductsController(DbProductContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["CreateSuccess"] = "Added successfully!";
                return RedirectToAction(nameof(Index));
                

            }

            return View(product);
            
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Image")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // As no file is being uploaded, only update the necessary properties
                    var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

                    if (productToUpdate != null)
                    {
                        productToUpdate.Name = product.Name;
                        productToUpdate.Description = product.Description;
                        productToUpdate.Price = product.Price;
                        productToUpdate.Image = product.Image; // Assuming this is the new image path

                        _context.Update(productToUpdate);
                        await _context.SaveChangesAsync();
                        TempData["EditSuccess"] = "Updated successfully!";

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error updating item: " + ex.Message;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }


        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            TempData["DeleteSuccess"] = "Deleted successfully!";
            return RedirectToAction(nameof(Index));
            
        }
    }
}
