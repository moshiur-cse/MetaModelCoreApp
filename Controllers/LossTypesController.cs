using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MetaModelCoreApp.Models;

namespace MetaModelCoreApp.Controllers
{
    public class LossTypesController : Controller
    {
        private readonly metamodel_db_testContext _context;

        public LossTypesController(metamodel_db_testContext context)
        {
            _context = context;
        }

        // GET: LossTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LossTypes.ToListAsync());
        }

        // GET: LossTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lossTypes = await _context.LossTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lossTypes == null)
            {
                return NotFound();
            }

            return View(lossTypes);
        }

        // GET: LossTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LossTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LossTypeName")] LossTypes lossTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lossTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lossTypes);
        }

        // GET: LossTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lossTypes = await _context.LossTypes.FindAsync(id);
            if (lossTypes == null)
            {
                return NotFound();
            }
            return View(lossTypes);
        }

        // POST: LossTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LossTypeName")] LossTypes lossTypes)
        {
            if (id != lossTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lossTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LossTypesExists(lossTypes.Id))
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
            return View(lossTypes);
        }

        // GET: LossTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lossTypes = await _context.LossTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lossTypes == null)
            {
                return NotFound();
            }

            return View(lossTypes);
        }

        // POST: LossTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lossTypes = await _context.LossTypes.FindAsync(id);
            _context.LossTypes.Remove(lossTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LossTypesExists(int id)
        {
            return _context.LossTypes.Any(e => e.Id == id);
        }
    }
}
