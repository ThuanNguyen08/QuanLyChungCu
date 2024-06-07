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
    public class SuCoesController : Controller
    {
        private readonly QuanLyChungCuContext _context;

        public SuCoesController(QuanLyChungCuContext context)
        {
            _context = context;
        }

        // GET: SuCoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SuCo.ToListAsync());
        }

        // GET: SuCoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suCo = await _context.SuCo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suCo == null)
            {
                return NotFound();
            }

            return View(suCo);
        }

        // GET: SuCoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuCoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCanHo,MoTaSuCo,NgayBaoCao,TrangThai,IdNhanVien")] SuCo suCo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suCo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suCo);
        }

        // GET: SuCoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suCo = await _context.SuCo.FindAsync(id);
            if (suCo == null)
            {
                return NotFound();
            }
            return View(suCo);
        }

        // POST: SuCoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCanHo,MoTaSuCo,NgayBaoCao,TrangThai,IdNhanVien")] SuCo suCo)
        {
            if (id != suCo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suCo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuCoExists(suCo.Id))
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
            return View(suCo);
        }

        // GET: SuCoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suCo = await _context.SuCo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suCo == null)
            {
                return NotFound();
            }

            return View(suCo);
        }

        // POST: SuCoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suCo = await _context.SuCo.FindAsync(id);
            if (suCo != null)
            {
                _context.SuCo.Remove(suCo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuCoExists(int id)
        {
            return _context.SuCo.Any(e => e.Id == id);
        }
    }
}
