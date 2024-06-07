using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class TienIch
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên tiện ích")]
        public string TenTienIch { get; set; }
        [Required]
        [Display(Name = "Vị trí")]
        public string Vitri {  get; set; }
        [Required]
        [Display(Name = "Giờ mở cửa")]
        [DataType(DataType.Date)]
        public DateTime GioMoCua { get; set; }
        [Required]
        [Display(Name = "Id nhân viên")]
        public int IdNhanVien { get; set; }
    }
}
