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
    public class ThuPhisController : Controller
    {
        private readonly QuanLyChungCuContext _context;

        public ThuPhisController(QuanLyChungCuContext context)
        {
            _context = context;
        }

        // GET: ThuPhis
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThuPhi.ToListAsync());
        }

        // GET: ThuPhis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuPhi = await _context.ThuPhi
                .FirstOrDefaultAsync(m => m.IdThuPhi == id);
            if (thuPhi == null)
            {
                return NotFound();
            }

            return View(thuPhi);
        }

        // GET: ThuPhis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThuPhis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThuPhi,IdDanCu,ThoiGian,PhiQuanLy,PhiDien,PhiNuoc,PhiDichVu,PhiGuiXe,NgayTao,TrangThai")] ThuPhi thuPhi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuPhi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thuPhi);
        }

        // GET: ThuPhis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuPhi = await _context.ThuPhi.FindAsync(id);
            if (thuPhi == null)
            {
                return NotFound();
            }
            return View(thuPhi);
        }

        // POST: ThuPhis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThuPhi,IdDanCu,ThoiGian,PhiQuanLy,PhiDien,PhiNuoc,PhiDichVu,PhiGuiXe,NgayTao,TrangThai")] ThuPhi thuPhi)
        {
            if (id != thuPhi.IdThuPhi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuPhi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuPhiExists(thuPhi.IdThuPhi))
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
            return View(thuPhi);
        }

        // GET: ThuPhis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuPhi = await _context.ThuPhi
                .FirstOrDefaultAsync(m => m.IdThuPhi == id);
            if (thuPhi == null)
            {
                return NotFound();
            }

            return View(thuPhi);
        }

        // POST: ThuPhis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuPhi = await _context.ThuPhi.FindAsync(id);
            if (thuPhi != null)
            {
                _context.ThuPhi.Remove(thuPhi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuPhiExists(int id)
        {
            return _context.ThuPhi.Any(e => e.IdThuPhi == id);
        }
    }
}
