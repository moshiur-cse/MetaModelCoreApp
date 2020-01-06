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
    public class LegendInfoesController : Controller
    {
        private readonly metamodel_db_testContext _context;

        public LegendInfoesController(metamodel_db_testContext context)
        {
            _context = context;
        }

        // GET: LegendInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LegendInfo.OrderBy(i=>i.Id).ToListAsync());
        }

        // GET: LegendInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legendInfo = await _context.LegendInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legendInfo == null)
            {
                return NotFound();
            }

            return View(legendInfo);
        }

        // GET: LegendInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LegendInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LengentName,LengentNameId,StartRange,EndRange,LegendColor")] LegendInfo legendInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legendInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legendInfo);
        }

        // GET: LegendInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legendInfo = await _context.LegendInfo.FindAsync(id);
            if (legendInfo == null)
            {
                return NotFound();
            }
            return View(legendInfo);
        }

        // POST: LegendInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LengentName,LengentNameId,StartRange,EndRange,LegendColor")] LegendInfo legendInfo)
        {
            if (id != legendInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legendInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegendInfoExists(legendInfo.Id))
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
            return View(legendInfo);
        }

        // GET: LegendInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legendInfo = await _context.LegendInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legendInfo == null)
            {
                return NotFound();
            }

            return View(legendInfo);
        }

        // POST: LegendInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legendInfo = await _context.LegendInfo.FindAsync(id);
            _context.LegendInfo.Remove(legendInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegendInfoExists(int id)
        {
            return _context.LegendInfo.Any(e => e.Id == id);
        }
    }
}
