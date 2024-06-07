using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class TaiKhoan
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int IdTaiKhoan { get; set; }
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [Required]
        [Display(Name = "Mật khẩu")]
        public string MatKhau{ get; set; }
        [Required]
        [Display(Name = "Vai trò")]
        public string VaiTro {  get; set; }
    }
}
