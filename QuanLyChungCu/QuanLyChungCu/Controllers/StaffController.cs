using Microsoft.AspNetCore.Mvc;

namespace QuanLyChungCu.Controllers
{
	public class StaffController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
