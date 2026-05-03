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
    public class ClassesController : Controller
    {
        private readonly OnePassFitnessContext _context;

        public ClassesController(OnePassFitnessContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var onePassFitnessContext = _context.Classes.Include(c => c.User);
            return View(await onePassFitnessContext.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ClassesId == id);
            if (classes == null)
            {
                return NotFound();
            }

            return View(classes);
        }

        
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Usersid", "Usersid");
            return View();
        }

        
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassesId,Classname,Date,Starttime,Endtime,UserId,Availability")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Usersid", "Usersid", classes.UserId);
            return View(classes);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes.FindAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Usersid", "Usersid", classes.UserId);
            return View(classes);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassesId,Classname,Date,Starttime,Endtime,UserId,Availability")] Classes classes)
        {
            if (id != classes.ClassesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassesExists(classes.ClassesId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Usersid", "Usersid", classes.UserId);
            return View(classes);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ClassesId == id);
            if (classes == null)
            {
                return NotFound();
            }

            return View(classes);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classes = await _context.Classes.FindAsync(id);
            if (classes != null)
            {
                _context.Classes.Remove(classes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassesExists(int id)
        {
            return _context.Classes.Any(e => e.ClassesId == id);
        }
    }
}
