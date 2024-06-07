using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyChungCu.Data;
using QuanLyChungCu.Models;

namespace QuanLyChungCu.Controllers
{
    public class TienIchesController : Controller
    {
        private readonly QuanLyChungCuContext _context;

        public TienIchesController(QuanLyChungCuContext context)
        {
            _context = context;
        }

        // GET: TienIches
        public async Task<IActionResult> Index()
        {
            return View(await _context.TienIch.ToListAsync());
        }

        // GET: TienIches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienIch = await _context.TienIch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tienIch == null)
            {
                return NotFound();
            }

            return View(tienIch);
        }

        // GET: TienIches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TienIches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenTienIch,Vitri,GioMoCua,IdNhanVien")] TienIch tienIch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tienIch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tienIch);
        }

        // GET: TienIches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienIch = await _context.TienIch.FindAsync(id);
            if (tienIch == null)
            {
                return NotFound();
            }
            return View(tienIch);
        }

        // POST: TienIches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenTienIch,Vitri,GioMoCua,IdNhanVien")] TienIch tienIch)
        {
            if (id != tienIch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tienIch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TienIchExists(tienIch.Id))
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
            return View(tienIch);
        }

        // GET: TienIches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienIch = await _context.TienIch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tienIch == null)
            {
                return NotFound();
            }

            return View(tienIch);
        }

        // POST: TienIches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tienIch = await _context.TienIch.FindAsync(id);
            if (tienIch != null)
            {
                _context.TienIch.Remove(tienIch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TienIchExists(int id)
        {
            return _context.TienIch.Any(e => e.Id == id);
        }
    }
}
