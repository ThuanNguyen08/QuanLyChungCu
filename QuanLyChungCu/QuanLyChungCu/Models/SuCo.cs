using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class SuCo
    {
        [Key]
        [Required]
        [Display(Name ="Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Id căn hộ")]
        public int IdCanHo {  get; set; }
        [Required]
        [Display(Name = "Mô tả sự cố")]
        public string MoTaSuCo {  get; set; }
        [Required]
        [Display(Name = "Ngày báo cáo")]
        [DataType(DataType.Date)]
        public DateTime NgayBaoCao { get; set; }
        [Required]
        [Display(Name = "Trạng thái")]
        public string TrangThai {  get; set; }
        [Required]
        [Display(Name = "Id nhân viên")]
        public int IdNhanVien {  get; set; }

    }
}
