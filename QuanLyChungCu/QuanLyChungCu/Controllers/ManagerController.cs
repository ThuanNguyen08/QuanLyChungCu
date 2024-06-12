using Microsoft.AspNetCore.Mvc;
using QuanLyChungCu.Data;
namespace QuanLyChungCu.Controllers
{
	public class ManagerController : Controller
	{
        private readonly QuanLyChungCuContext _context;

		public ManagerController(QuanLyChungCuContext context)
		{
			_context = context;
		}
        public IActionResult Index()
        {
            return View();
        }
    }
}
