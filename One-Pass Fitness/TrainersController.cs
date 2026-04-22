using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using One_Pass_Fitness.Data;
using One_Pass_Fitness.Models;

namespace One_Pass_Fitness
{
    public class TrainersController : Controller
    {
        private readonly OnePassFitnessContext _context;

        public TrainersController(OnePassFitnessContext context)
        {
            _context = context;
        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
            var onePassFitnessContext = _context.Trainers.Include(t => t.Person);
            return View(await onePassFitnessContext.ToListAsync());
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers
                .Include(t => t.Person)
                .FirstOrDefaultAsync(m => m.Trainersid == id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }

        // GET: Trainers/Create
        public IActionResult Create()
        {
            ViewData["Personid"] = new SelectList(_context.Personalinfo, "Personalinfoid", "Email");
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Trainersid,Personid,Trainedfield,Datehired")] Trainers trainers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Personid"] = new SelectList(_context.Personalinfo, "Personalinfoid", "Email", trainers.Personid);
            return View(trainers);
        }

        // GET: Trainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers.FindAsync(id);
            if (trainers == null)
            {
                return NotFound();
            }
            ViewData["Personid"] = new SelectList(_context.Personalinfo, "Personalinfoid", "Email", trainers.Personid);
            return View(trainers);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Trainersid,Personid,Trainedfield,Datehired")] Trainers trainers)
        {
            if (id != trainers.Trainersid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainersExists(trainers.Trainersid))
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
            ViewData["Personid"] = new SelectList(_context.Personalinfo, "Personalinfoid", "Email", trainers.Personid);
            return View(trainers);
        }

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers
                .Include(t => t.Person)
                .FirstOrDefaultAsync(m => m.Trainersid == id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainers = await _context.Trainers.FindAsync(id);
            if (trainers != null)
            {
                _context.Trainers.Remove(trainers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainersExists(int id)
        {
            return _context.Trainers.Any(e => e.Trainersid == id);
        }
    }
}
