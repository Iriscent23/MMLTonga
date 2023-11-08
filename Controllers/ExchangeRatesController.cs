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
    public class ExchangeRatesController : Controller
    {
        private readonly DbRateContext _context;

        public ExchangeRatesController(DbRateContext context)
        {
            _context = context;
        }

        // GET: ExchangeRates
        public async Task<IActionResult> Index()
        {
            return _context.ExchangeRates != null ?
                        View(await _context.ExchangeRates.ToListAsync()) :
                        Problem("Entity set 'DbRateContext.ExchangeRates'  is null.");
        }

        // GET: ExchangeRates/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ExchangeRates == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .FirstOrDefaultAsync(m => m.Country == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // GET: ExchangeRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExchangeRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Country,Currency,SendRate,ReceiveRate")] ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exchangeRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exchangeRate);
        }

        // GET: ExchangeRates/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ExchangeRates == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate == null)
            {
                return NotFound();
            }
            return View(exchangeRate);
        }

        // POST: ExchangeRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Country,Currency,SendRate,ReceiveRate")] ExchangeRate exchangeRate)
        {
            if (id != exchangeRate.Country)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exchangeRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExchangeRateExists(exchangeRate.Country))
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
            return View(exchangeRate);
        }

        // GET: ExchangeRates/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ExchangeRates == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .FirstOrDefaultAsync(m => m.Country == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // POST: ExchangeRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ExchangeRates == null)
            {
                return Problem("Entity set 'DbRateContext.ExchangeRates'  is null.");
            }
            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate != null)
            {
                _context.ExchangeRates.Remove(exchangeRate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExchangeRateExists(string id)
        {
            return (_context.ExchangeRates?.Any(e => e.Country == id)).GetValueOrDefault();
        }
    }
}
