using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPTEST.Data;
using APPTEST.Models;

namespace APPTEST.Controllers
{
    public class MUZsController : Controller
    {
        private readonly APPTESTContext _context;

        public MUZsController(APPTESTContext context)
        {
            _context = context;
        }

        // GET: MUZs
        public async Task<IActionResult> Index()
        {
              return _context.MUZ != null ? 
                          View(await _context.MUZ.ToListAsync()) :
                          Problem("Entity set 'APPTESTContext.MUZ'  is null.");
        }

        // GET: MUZs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MUZ == null)
            {
                return NotFound();
            }

            var mUZ = await _context.MUZ
                .FirstOrDefaultAsync(m => m.MuzID == id);
            if (mUZ == null)
            {
                return NotFound();
            }

            return View(mUZ);
        }

        // GET: MUZs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MUZs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MuzID,MuzName,Opis,Link")] MUZ mUZ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mUZ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mUZ);
        }

        // GET: MUZs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MUZ == null)
            {
                return NotFound();
            }

            var mUZ = await _context.MUZ.FindAsync(id);
            if (mUZ == null)
            {
                return NotFound();
            }
            return View(mUZ);
        }

        // POST: MUZs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MuzID,MuzName,Opis,Link")] MUZ mUZ)
        {
            if (id != mUZ.MuzID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mUZ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MUZExists(mUZ.MuzID))
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
            return View(mUZ);
        }

        // GET: MUZs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MUZ == null)
            {
                return NotFound();
            }

            var mUZ = await _context.MUZ
                .FirstOrDefaultAsync(m => m.MuzID == id);
            if (mUZ == null)
            {
                return NotFound();
            }

            return View(mUZ);
        }

        // POST: MUZs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MUZ == null)
            {
                return Problem("Entity set 'APPTESTContext.MUZ'  is null.");
            }
            var mUZ = await _context.MUZ.FindAsync(id);
            if (mUZ != null)
            {
                _context.MUZ.Remove(mUZ);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MUZExists(int id)
        {
          return (_context.MUZ?.Any(e => e.MuzID == id)).GetValueOrDefault();
        }
    }
}
