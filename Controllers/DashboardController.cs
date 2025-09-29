using Microsoft.AspNetCore.Mvc;

namespace dotnet_mvc_first_app.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            return View();
        }
    }
}
