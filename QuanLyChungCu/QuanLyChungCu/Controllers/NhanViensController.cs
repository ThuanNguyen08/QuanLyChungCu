using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuanLyChungCu.Data;
using QuanLyChungCu.Models;

namespace QuanLyChungCu.Controllers
{
    public class NhanViensController : Controller
    {
        private readonly QuanLyChungCuContext _context;

        public NhanViensController(QuanLyChungCuContext context)
        {
            _context = context;
        }

        // GET: NhanViens
        public async Task<IActionResult> Index(string sortOrder)
        {
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "id_asc";
            }
            ViewData["IdSortParm"] = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewData["NameSortParm"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["SexSortParm"] = sortOrder == "sex_asc" ? "sex_desc" : "sex_asc";
            ViewData["DateSortParm"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["DateSortParm"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            var nhanviens = from s in _context.NhanVien
                           select s;
            switch (sortOrder)
            {
                case "id_asc":
                    nhanviens = nhanviens.OrderBy(s => s.IdNhanVien);
                    break;
                case "id_desc":
                    nhanviens = nhanviens.OrderBy(s => s.IdNhanVien);
                    break;
                case "name_asc":
                    nhanviens = nhanviens.OrderBy(s => s.TenNhanVien);
                    break;
                case "name_desc":
                    nhanviens = nhanviens.OrderByDescending(s => s.TenNhanVien);
                    break;
                case "sex_asc":
                    nhanviens = nhanviens.OrderBy(s => s.GioiTinh);
                    break;
                case "sex_desc":
                    nhanviens = nhanviens.OrderByDescending(s => s.GioiTinh);
                    break;
                case "date_asc":
                    nhanviens = nhanviens.OrderBy(s => s.NgaySinh);
                    break;
                case "date_desc":
                    nhanviens = nhanviens.OrderByDescending(s => s.NgaySinh);
                    break;
                default:
                    nhanviens = nhanviens.OrderBy(s => s.TenNhanVien);
                    break;
            }

            return View(await nhanviens.AsNoTracking().ToListAsync());
        }

        // GET: NhanViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .FirstOrDefaultAsync(m => m.IdNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhanVien,TenNhanVien,GioiTinh,NgaySinh,Sdt,Email,DiaChi,IdTaiKhoan")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNhanVien,TenNhanVien,GioiTinh,NgaySinh,Sdt,Email,DiaChi,IdTaiKhoan")] NhanVien nhanVien)
        {
            if (id != nhanVien.IdNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.IdNhanVien))
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
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .FirstOrDefaultAsync(m => m.IdNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanVien.Remove(nhanVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanVien.Any(e => e.IdNhanVien == id);
        }
    }
}
