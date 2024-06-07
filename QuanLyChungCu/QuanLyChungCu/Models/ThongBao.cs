using System.ComponentModel.DataAnnotations;

namespace QuanLyChungCu.Models
{
    public class ThongBao
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Required]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Required]
        [Display(Name = "Ngày gửi")]
        [DataType(DataType.Date)]
        public string NgayGui { get; set; }
        [Required]
        [Display(Name = "Id người gửi")]
        public int IdNguoiGui { get; set; }
        [Required]
        [Display(Name = "Id người nhận")]
        public int IdNguoiNhan {  get; set; }


    }
}
