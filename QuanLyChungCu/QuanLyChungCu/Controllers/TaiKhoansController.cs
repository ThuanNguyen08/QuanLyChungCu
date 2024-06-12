using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyChungCu.Data;
using QuanLyChungCu.Migrations;
using QuanLyChungCu.Models;

namespace QuanLyChungCu.Controllers
{
    public class TaiKhoansController : Controller
    {
        private readonly QuanLyChungCuContext _context;

        public TaiKhoansController(QuanLyChungCuContext context)
        {
            _context = context;
        }

        // GET: TaiKhoans

        [HttpGet]
		public IActionResult Index()
		{
			if (HttpContext.Session.GetString("TenDangNhap") == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Manager");
			}
		}
        public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(TaiKhoan tk)
		{

			if (HttpContext.Session.GetString("TenDangNhap") == null)
			{
				var u = _context.TaiKhoan
								.Where(x => x.TenDangNhap.Equals(tk.TenDangNhap) && x.MatKhau.Equals(tk.MatKhau))
								.FirstOrDefault();
				if (u != null)
				{
					HttpContext.Session.SetString("TenDangNhap", u.TenDangNhap.ToString());
					return RedirectToAction("Index", "Manager");
				}
                else
                {
                    ViewData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View(tk);
                }
            }
			else
			{
				return RedirectToAction("Index", "Manager");
			}
        }


		[HttpPost]
        public IActionResult Logout()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("accname")))
            {
                HttpContext.Session.SetString("accname", "");
                return RedirectToAction("Login", "TaiKhoans");
            }
            return RedirectToAction("Login", "TaiKhoans");
        }



        // GET: TaiKhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan
                .FirstOrDefaultAsync(m => m.IdTaiKhoan == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // GET: TaiKhoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTaiKhoan,TenDangNhap,MatKhau,VaiTro")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiKhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTaiKhoan,TenDangNhap,MatKhau,VaiTro")] TaiKhoan taiKhoan)
        {
            if (id != taiKhoan.IdTaiKhoan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiKhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanExists(taiKhoan.IdTaiKhoan))
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
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan
                .FirstOrDefaultAsync(m => m.IdTaiKhoan == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // POST: TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taiKhoan = await _context.TaiKhoan.FindAsync(id);
            if (taiKhoan != null)
            {
                _context.TaiKhoan.Remove(taiKhoan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanExists(int id)
        {
            return _context.TaiKhoan.Any(e => e.IdTaiKhoan == id);
        }
    }
}
