using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyChungCu.Models;

namespace QuanLyChungCu.Data
{
    public class QuanLyChungCuContext : DbContext
    {
        public QuanLyChungCuContext (DbContextOptions<QuanLyChungCuContext> options)
            : base(options)
        {
        }

        public DbSet<QuanLyChungCu.Models.CanHo> CanHo { get; set; } = default!;
        public DbSet<QuanLyChungCu.Models.DanCu> DanCu { get; set; } = default!;
        public DbSet<QuanLyChungCu.Models.NhanVien> NhanVien { get; set; } = default!;
        public DbSet<QuanLyChungCu.Models.HopDong> HopDong { get; set; } = default!;
        public DbSet<QuanLyChungCu.Models.TaiKhoan> TaiKhoan { get; set; } = default!;
        public DbSet<QuanLyChungCu.Models.SuCo> SuCo { get; set; } = default!;
        public DbSet<QuanLyChungCu.Models.ThongBao> ThongBao { get; set; } = default!;
        public DbSet<QuanLyChungCu.Models.ThuPhi> ThuPhi { get; set; } = default!;
        public DbSet<QuanLyChungCu.Models.TienIch> TienIch { get; set; } = default!;
    }
}
