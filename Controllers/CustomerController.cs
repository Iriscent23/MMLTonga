using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MMLTonga.Data;
using MMLTonga.Models;

namespace MMLTonga.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DbCustomerContext _context;

        public CustomerController(DbCustomerContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return _context.Customers != null ?
                        View(await _context.Customers.ToListAsync()) :
                        Problem("Entity set 'DbCustomerContext.Customers'  is null.");
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerManagement = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerManagement == null)
            {
                return NotFound();
            }

            return View(customerManagement);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Email,PhoneNumber")] CustomerManagement customerManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerManagement);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerManagement = await _context.Customers.FindAsync(id);
            if (customerManagement == null)
            {
                return NotFound();
            }
            return View(customerManagement);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Email,PhoneNumber")] CustomerManagement customerManagement)
        {
            if (id != customerManagement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerManagementExists(customerManagement.Id))
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
            return View(customerManagement);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerManagement = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerManagement == null)
            {
                return NotFound();
            }

            return View(customerManagement);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'DbCustomerContext.Customers'  is null.");
            }
            var customerManagement = await _context.Customers.FindAsync(id);
            if (customerManagement != null)
            {
                _context.Customers.Remove(customerManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerManagementExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
