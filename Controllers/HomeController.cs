using Microsoft.AspNetCore.Mvc;

namespace Barbearia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}