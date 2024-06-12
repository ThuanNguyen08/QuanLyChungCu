using Microsoft.AspNetCore.Mvc;
using QuanLyChungCu.Data;

namespace QuanLyChungCu.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly QuanLyChungCuContext _context;
        public ThongKeController(QuanLyChungCuContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Truy vấn dữ liệu từ bảng ThuPhi
            var thuPhiData = _context.ThuPhi.ToList();

            // Xử lý dữ liệu để chuẩn bị cho biểu đồ (ví dụ: tính tổng phí theo thời gian)
            var dataForChart = thuPhiData.GroupBy(tp => tp.ThoiGian)
                                          .Select(group => new
                                          {
                                              ThoiGian = group.Key,
                                              TongPhi = group.Sum(tp => tp.PhiQuanLy + tp.PhiDien + tp.PhiNuoc + tp.PhiDichVu + tp.PhiGuiXe)
                                          })
                                          .OrderBy(item => item.ThoiGian)
                                          .ToList();

            // Chuẩn bị dữ liệu cho biểu đồ
            var labels = dataForChart.Select(item => item.ThoiGian).ToArray();
            var data = dataForChart.Select(item => item.TongPhi).ToArray();

            // Trả về view với dữ liệu cho biểu đồ
            ViewBag.Labels = labels;
            ViewBag.Data = data;

            return View();
        }
    }
}
