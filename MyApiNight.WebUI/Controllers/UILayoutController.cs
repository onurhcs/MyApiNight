using Microsoft.AspNetCore.Mvc;

namespace MyApiNight.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
