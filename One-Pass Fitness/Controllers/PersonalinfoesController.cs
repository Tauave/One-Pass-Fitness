using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using One_Pass_Fitness.Data;
using One_Pass_Fitness.Models;

namespace One_Pass_Fitness.Controllers
{
    public class PersonalinfoesController : Controller
    {
        private readonly OnePassFitnessContext _context;

        public PersonalinfoesController(OnePassFitnessContext context)
        {
            _context = context;
        }

        // GET: Personalinfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personalinfo.ToListAsync());
        }

        // GET: Personalinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.Personalinfo
                .FirstOrDefaultAsync(m => m.Personalinfoid == id);
            if (personalinfo == null)
            {
                return NotFound();
            }

            return View(personalinfo);
        }

        // GET: Personalinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personalinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Personalinfoid,Name,Lastname,DOB,Email,Phone")] Personalinfo personalinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalinfo);
        }

        // GET: Personalinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.Personalinfo.FindAsync(id);
            if (personalinfo == null)
            {
                return NotFound();
            }
            return View(personalinfo);
        }

        // POST: Personalinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Personalinfoid,Name,Lastname,DOB,Email,Phone")] Personalinfo personalinfo)
        {
            if (id != personalinfo.Personalinfoid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalinfoExists(personalinfo.Personalinfoid))
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
            return View(personalinfo);
        }

        // GET: Personalinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.Personalinfo
                .FirstOrDefaultAsync(m => m.Personalinfoid == id);
            if (personalinfo == null)
            {
                return NotFound();
            }

            return View(personalinfo);
        }

        // POST: Personalinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalinfo = await _context.Personalinfo.FindAsync(id);
            if (personalinfo != null)
            {
                _context.Personalinfo.Remove(personalinfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalinfoExists(int id)
        {
            return _context.Personalinfo.Any(e => e.Personalinfoid == id);
        }
    }
}
