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
    public class DanCusController : Controller
    {
        private readonly QuanLyChungCuContext _context;

        public DanCusController(QuanLyChungCuContext context)
        {
            _context = context;
        }

        // GET: DanCus
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanCu.ToListAsync());
        }

        // GET: DanCus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danCu = await _context.DanCu
                .FirstOrDefaultAsync(m => m.IdDanCu == id);
            if (danCu == null)
            {
                return NotFound();
            }

            return View(danCu);
        }

        // GET: DanCus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanCus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanCu,HoTen,NgaySinh,GioiTinh,Sdt,Email,DiaChi,VaiTro,IdCanHo")] DanCu danCu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danCu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danCu);
        }

        // GET: DanCus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danCu = await _context.DanCu.FindAsync(id);
            if (danCu == null)
            {
                return NotFound();
            }
            return View(danCu);
        }

        // POST: DanCus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanCu,HoTen,NgaySinh,GioiTinh,Sdt,Email,DiaChi,VaiTro,IdCanHo")] DanCu danCu)
        {
            if (id != danCu.IdDanCu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danCu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanCuExists(danCu.IdDanCu))
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
            return View(danCu);
        }

        // GET: DanCus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danCu = await _context.DanCu
                .FirstOrDefaultAsync(m => m.IdDanCu == id);
            if (danCu == null)
            {
                return NotFound();
            }

            return View(danCu);
        }

        // POST: DanCus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danCu = await _context.DanCu.FindAsync(id);
            if (danCu != null)
            {
                _context.DanCu.Remove(danCu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanCuExists(int id)
        {
            return _context.DanCu.Any(e => e.IdDanCu == id);
        }
    }
}
