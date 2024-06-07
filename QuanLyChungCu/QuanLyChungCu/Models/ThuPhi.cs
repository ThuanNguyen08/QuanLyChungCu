using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class ThuPhi
    {
        [Key]
        [Required]
        [Display(Name = "Id thu phí")]
        public int IdThuPhi { get; set; }
        [Required]
        [Display(Name = "Id dân cư")]
        public int IdDanCu {  get; set; }
        [Required]
        [Display(Name = "Thời gian")]
        public string ThoiGian { get; set; }
        [Required]
        [Display(Name = "Phí quản lý")]
        public double PhiQuanLy {  get; set; }
        [Required]
        [Display(Name = "Phí điện")]
        public double PhiDien {  get; set; }
        [Required]
        [Display(Name = "Phí nước")]
        public double PhiNuoc {  get; set; }
        [Required]
        [Display(Name = "Phí dịch vụ")]
        public double PhiDichVu { get; set; }
        [Required]
        [Display(Name = "Phí gửi xe")]
        public double PhiGuiXe { get; set; }
        [Required]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime NgayTao { get; set; }
        [Required]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }
    }
}
