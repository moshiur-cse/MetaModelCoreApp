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
    public class SenariosController : Controller
    {
        private readonly metamodel_db_testContext _context;

        public SenariosController(metamodel_db_testContext context)
        {
            _context = context;
        }

        // GET: Senarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Senarios.ToListAsync());
        }

        // GET: Senarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senarios = await _context.Senarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (senarios == null)
            {
                return NotFound();
            }

            return View(senarios);
        }

        // GET: Senarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Senarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClimateSenarioScale,EconomicSenarioScale,SenarioName,ScenarioCombineName,ClimateImage,EconomicImage")] Senarios senarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(senarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(senarios);
        }

        // GET: Senarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senarios = await _context.Senarios.FindAsync(id);
            if (senarios == null)
            {
                return NotFound();
            }
            return View(senarios);
        }

        // POST: Senarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClimateSenarioScale,EconomicSenarioScale,SenarioName,ScenarioCombineName,ClimateImage,EconomicImage")] Senarios senarios)
        {
            if (id != senarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(senarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SenariosExists(senarios.Id))
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
            return View(senarios);
        }

        // GET: Senarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senarios = await _context.Senarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (senarios == null)
            {
                return NotFound();
            }

            return View(senarios);
        }

        // POST: Senarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var senarios = await _context.Senarios.FindAsync(id);
            _context.Senarios.Remove(senarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SenariosExists(int id)
        {
            return _context.Senarios.Any(e => e.Id == id);
        }
    }
}
