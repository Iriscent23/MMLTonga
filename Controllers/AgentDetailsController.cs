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
    public class AgentDetailsController : Controller
    {
        private readonly DbAgentContext _context;

        public AgentDetailsController(DbAgentContext context)
        {
            _context = context;
        }

        // GET: AgentDetails
        public async Task<IActionResult> Index()
        {
            return _context.AgentDetails != null ?
                        View(await _context.AgentDetails.ToListAsync()) :
                        Problem("Entity set 'DbAgentContext.AgentDetails'  is null.");
        }

        // GET: AgentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AgentDetails == null)
            {
                return NotFound();
            }

            var agentDetail = await _context.AgentDetails
                .FirstOrDefaultAsync(m => m.AgentID == id);
            if (agentDetail == null)
            {
                return NotFound();
            }

            return View(agentDetail);
        }

        // GET: AgentDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgentID,AgentCompany,Address,Email,PhoneNumber")] AgentDetail agentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agentDetail);
        }

        // GET: AgentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AgentDetails == null)
            {
                return NotFound();
            }

            var agentDetail = await _context.AgentDetails.FindAsync(id);
            if (agentDetail == null)
            {
                return NotFound();
            }
            return View(agentDetail);
        }

        // POST: AgentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgentID,AgentCompany,Address,Email,PhoneNumber")] AgentDetail agentDetail)
        {
            if (id != agentDetail.AgentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agentDetail);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Updated successfully";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!AgentDetailExists(agentDetail.AgentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error updating agent: " + ex.Message;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agentDetail);
        }

        // GET: AgentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AgentDetails == null)
            {
                return NotFound();
            }

            var agentDetail = await _context.AgentDetails
                .FirstOrDefaultAsync(m => m.AgentID == id);
            if (agentDetail == null)
            {
                return NotFound();
            }

            return View(agentDetail);
        }

        // POST: AgentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AgentDetails == null)
            {
                return Problem("Entity set 'DbAgentContext.AgentDetails'  is null.");
            }
            var agentDetail = await _context.AgentDetails.FindAsync(id);
            if (agentDetail != null)
            {
                _context.AgentDetails.Remove(agentDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentDetailExists(int id)
        {
            return (_context.AgentDetails?.Any(e => e.AgentID == id)).GetValueOrDefault();
        }
    }
}
