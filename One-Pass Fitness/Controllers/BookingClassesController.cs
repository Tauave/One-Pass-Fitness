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
    public class BookingClassesController : Controller
    {
        private readonly OnePassFitnessContext _context;

        public BookingClassesController(OnePassFitnessContext context)
        {
            _context = context;
        }

        // GET: BookingClasses
        public async Task<IActionResult> Index()
        {
            var onePassFitnessContext = _context.BookingClasses.Include(b => b.Class).Include(b => b.Member);
            return View(await onePassFitnessContext.ToListAsync());
        }

        // GET: BookingClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingClasses = await _context.BookingClasses
                .Include(b => b.Class)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.BookingClassesId == id);
            if (bookingClasses == null)
            {
                return NotFound();
            }

            return View(bookingClasses);
        }

        // GET: BookingClasses/Create
        public IActionResult Create()
        {
            ViewData["Classid"] = new SelectList(_context.Classes, "ClassesId", "Classname");
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid");
            return View();
        }

        // POST: BookingClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingClassesId,Memberid,Classid,Bookingdate,Attendancestatus")] BookingClasses bookingClasses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingClasses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Classid"] = new SelectList(_context.Classes, "ClassesId", "Classname", bookingClasses.Classid);
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", bookingClasses.Memberid);
            return View(bookingClasses);
        }

        // GET: BookingClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingClasses = await _context.BookingClasses.FindAsync(id);
            if (bookingClasses == null)
            {
                return NotFound();
            }
            ViewData["Classid"] = new SelectList(_context.Classes, "ClassesId", "Classname", bookingClasses.Classid);
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", bookingClasses.Memberid);
            return View(bookingClasses);
        }

        // POST: BookingClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingClassesId,Memberid,Classid,Bookingdate,Attendancestatus")] BookingClasses bookingClasses)
        {
            if (id != bookingClasses.BookingClassesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingClasses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingClassesExists(bookingClasses.BookingClassesId))
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
            ViewData["Classid"] = new SelectList(_context.Classes, "ClassesId", "Classname", bookingClasses.Classid);
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", bookingClasses.Memberid);
            return View(bookingClasses);
        }

        // GET: BookingClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingClasses = await _context.BookingClasses
                .Include(b => b.Class)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.BookingClassesId == id);
            if (bookingClasses == null)
            {
                return NotFound();
            }

            return View(bookingClasses);
        }

        // POST: BookingClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingClasses = await _context.BookingClasses.FindAsync(id);
            if (bookingClasses != null)
            {
                _context.BookingClasses.Remove(bookingClasses);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingClassesExists(int id)
        {
            return _context.BookingClasses.Any(e => e.BookingClassesId == id);
        }
    }
}
