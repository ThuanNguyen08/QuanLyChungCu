using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class CanHo
    {
        [Key]
        [Required]
        [Display(Name = "Id căn hộ")]
        public int IdCanHo { get; set; }
        [Required]
        [Display(Name = "Số căn hộ")]
        public string SoCanHo { get; set; }
        [Required]
        [Display(Name = "Số tầng")]
        public string Tang { get; set; }
        [Required]
        [Display(Name = "Diện tích")]
        public string DienTich {  get; set; }
        [Required]
        [Display(Name = "Loại căn hộ")]
        public string LoaiCanHo { get; set; }
        [Required]
        [Display(Name = "Tình trạng")]
        public string TinhTrang { get; set; }
        [Required]
        [Display(Name = "Id dân cư")]
        public int IdDanCu { get; set; }
        [Required]
        [Display(Name = "Id hợp đồng")]
        public int IdHopDong { get; set; }

    }
}
