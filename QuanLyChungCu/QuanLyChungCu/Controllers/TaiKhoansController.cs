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
            if (HttpContext.Session.GetInt32("IdTaiKhoan") == null)
            {
                var u = await _context.TaiKhoan
                                     .Where(x => x.TenDangNhap.Equals(tk.TenDangNhap) && x.MatKhau.Equals(tk.MatKhau))
                                     .FirstOrDefaultAsync();

                if (u != null)
                {
                    HttpContext.Session.SetInt32("IdTaiKhoan", u.IdTaiKhoan);
                    HttpContext.Session.SetString("VaiTro", u.VaiTro);

                    // Điều hướng dựa trên vai trò
                    if (u.VaiTro == "quan ly")
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                    else if (u.VaiTro == "dan cu")
                    {
                        return RedirectToAction("Index", "DanCu");
                    }
                    else
                    {
                        // Vai trò không xác định, điều hướng về trang mặc định hoặc thông báo lỗi
                        ViewData["ErrorMessage"] = "Vai trò không hợp lệ.";
                        return View(tk);
                    }
                }
                else
                {
                    ViewData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View(tk);
                }
            }
            else
            {
                return RedirectToAction("Index", "DanCu");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the login page
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

        // GET: TaiKhoans/Edit
        public async Task<IActionResult> Edit()
        {
            // Retrieve the Id from the session
            var userId = HttpContext.Session.GetInt32("IdTaiKhoan");

            // Check if the session Id is null
            if (userId == null)
            {
                return RedirectToAction("Login", "TaiKhoans");
            }

            // Fetch the user record from the database based on the session Id
            var taiKhoan = await _context.TaiKhoan.FirstOrDefaultAsync(x => x.IdTaiKhoan == userId);

            // Check if the user record exists
            if (taiKhoan == null)
            {
                return NotFound();
            }

            // Return the Edit view with the user data
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("IdTaiKhoan,TenDangNhap,MatKhau,VaiTro")] TaiKhoan taiKhoan)
        {
            // Retrieve the Id from the session
            var userId = HttpContext.Session.GetInt32("IdTaiKhoan");

            // Check if the session Id is null
            if (userId == null || userId != taiKhoan.IdTaiKhoan)
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
