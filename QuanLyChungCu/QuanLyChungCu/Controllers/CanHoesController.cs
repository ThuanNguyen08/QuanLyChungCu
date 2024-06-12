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
    public class CanHoesController : Controller
    {
        private readonly QuanLyChungCuContext _context;

        public CanHoesController(QuanLyChungCuContext context)
        {
            _context = context;
        }

        // GET: CanHoes
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.CanHo == null)
            {
                return Problem("QuanLyChungCuContext.CanHo is Null");
            }

            var canhos = from m in _context.CanHo
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                canhos = canhos.Where(s => s.SoCanHo!.Contains(searchString));
            }

            return View(await canhos.ToListAsync());
        }

        // GET: CanHoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canHo = await _context.CanHo
                .FirstOrDefaultAsync(m => m.IdCanHo == id);
            if (canHo == null)
            {
                return NotFound();
            }

            return View(canHo);
        }

        // GET: CanHoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CanHoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCanHo,SoCanHo,Tang,DienTich,LoaiCanHo,TinhTrang,IdDanCu,IdHopDong")] CanHo canHo)
        {
            if (ModelState.IsValid)
            {

                _context.Add(canHo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(canHo);
        }

        // GET: CanHoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canHo = await _context.CanHo.FindAsync(id);
            if (canHo == null)
            {
                return NotFound();
            }
            return View(canHo);
        }

        // POST: CanHoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCanHo,SoCanHo,Tang,DienTich,LoaiCanHo,TinhTrang,IdDanCu,IdHopDong")] CanHo canHo)
        {
            if (id != canHo.IdCanHo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canHo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanHoExists(canHo.IdCanHo))
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
            return View(canHo);
        }

        // GET: CanHoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canHo = await _context.CanHo
                .FirstOrDefaultAsync(m => m.IdCanHo == id);
            if (canHo == null)
            {
                return NotFound();
            }

            return View(canHo);
        }

        // POST: CanHoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canHo = await _context.CanHo.FindAsync(id);
            if (canHo != null)
            {
                _context.CanHo.Remove(canHo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanHoExists(int id)
        {
            return _context.CanHo.Any(e => e.IdCanHo == id);
        }
    }
}
