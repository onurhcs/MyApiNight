using Microsoft.AspNetCore.Mvc;

namespace MyApiNight.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
