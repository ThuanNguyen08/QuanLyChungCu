using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class NhanVien
    {
        [Key]
        [Required]
        [Display(Name = "Id nhân viên")]
        public int IdNhanVien { get; set; }
        [Required]
        [Display(Name = "Họ và tên")]
        public string TenNhanVien { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        [Required]
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^(?:[0-9]|\+){1,}[0-9]{9,}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Sdt {  get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Địa chỉ")]
        public  string DiaChi { get; set; }
        [Required]
        [Display(Name = "Id tài khoản")]
        public int IdTaiKhoan { get; set; }

    }
}