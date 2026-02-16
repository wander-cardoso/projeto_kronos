using Microsoft.AspNetCore.Mvc;

namespace ProjKronos.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
