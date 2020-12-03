using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PayscalesController : Controller
    {
        private readonly PayScaleDbContext _context;

        public PayscalesController(PayScaleDbContext context)
        {
            _context = context;
        }

        // GET: Payscales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Payscales.ToListAsync());
        }

        // GET: Payscales/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payscale = await _context.Payscales
                .FirstOrDefaultAsync(m => m.PayBand == id);
            if (payscale == null)
            {
                return NotFound();
            }

            return View(payscale);
        }

        // GET: Payscales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payscales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayBand,BasicSalary,Hra,Ta,Da,NetSalary,InHandSalary")] Payscale payscale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payscale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payscale);
        }

        // GET: Payscales/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payscale = await _context.Payscales.FindAsync(id);
            if (payscale == null)
            {
                return NotFound();
            }
            return View(payscale);
        }

        // POST: Payscales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PayBand,BasicSalary,Hra,Ta,Da,NetSalary,InHandSalary")] Payscale payscale)
        {
            if (id != payscale.PayBand)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payscale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayscaleExists(payscale.PayBand))
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
            return View(payscale);
        }

        // GET: Payscales/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payscale = await _context.Payscales
                .FirstOrDefaultAsync(m => m.PayBand == id);
            if (payscale == null)
            {
                return NotFound();
            }

            return View(payscale);
        }

        // POST: Payscales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var payscale = await _context.Payscales.FindAsync(id);
            _context.Payscales.Remove(payscale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayscaleExists(string id)
        {
            return _context.Payscales.Any(e => e.PayBand == id);
        }
    }
}
