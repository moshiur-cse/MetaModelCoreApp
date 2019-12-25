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
    public class CropTypesController : Controller
    {
        private readonly MetaModelDbContext _context;

        public CropTypesController(MetaModelDbContext context)
        {
            _context = context;
        }

        // GET: CropTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CropType.ToListAsync());
        }

        // GET: CropTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropType = await _context.CropType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cropType == null)
            {
                return NotFound();
            }

            return View(cropType);
        }

        // GET: CropTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CropTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CropTypeName")] CropType cropType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cropType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cropType);
        }

        // GET: CropTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropType = await _context.CropType.FindAsync(id);
            if (cropType == null)
            {
                return NotFound();
            }
            return View(cropType);
        }

        // POST: CropTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CropTypeName")] CropType cropType)
        {
            if (id != cropType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cropType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CropTypeExists(cropType.Id))
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
            return View(cropType);
        }

        // GET: CropTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropType = await _context.CropType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cropType == null)
            {
                return NotFound();
            }

            return View(cropType);
        }

        // POST: CropTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cropType = await _context.CropType.FindAsync(id);
            _context.CropType.Remove(cropType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CropTypeExists(int id)
        {
            return _context.CropType.Any(e => e.Id == id);
        }
    }
}
