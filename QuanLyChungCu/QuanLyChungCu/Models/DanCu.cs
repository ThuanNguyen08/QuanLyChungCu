using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class DanCu
    {
        [Key]
        [Required]
        [Display(Name = "Id dân cư")]
        public int IdDanCu { get; set; }
        [Required]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
        [Required]
        [Display(Name = "Số điện thoại")]
        public string Sdt { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Required]
        [Display(Name = "Vai trò")]
        public string VaiTro { get; set; }
        [Required]
        [Display(Name = "Id căn hộ")]
        public int IdCanHo {  get; set; }
        public int IdTaiKhoan { get; set; }
    }
}
