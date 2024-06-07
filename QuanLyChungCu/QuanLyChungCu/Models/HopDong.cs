using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class HopDong
    {
        [Key]
        [Required]
        [Display(Name = "Id hợp đồng")]
        public int IdHopDong { get; set; }
        [Required]
        [Display(Name = "Id căn hộ")]
        public int IdCanHo { get; set; }
        [Required]
        [Display(Name = "Id dân cư")]
        public int IdDanCu { get; set; }
        [Required]
        [Display(Name = "Id nhân viên")]
        public int IdNhanVien { get; set; }
        [Required]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime NgayTao { get; set; }
        [Required]
        [Display(Name = "Ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }
        [Required]
        [Display(Name = "Ngày kết thúc")]
        [DataType(DataType.Date)]
        public DateTime NgayKetThuc {  get; set; }
        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

    }
}
