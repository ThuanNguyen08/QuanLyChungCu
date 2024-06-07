using Microsoft.AspNetCore.Mvc;

namespace QuanLyChungCu.Controllers
{
	public class ManagerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
