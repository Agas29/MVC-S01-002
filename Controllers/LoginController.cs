using Microsoft.AspNetCore.Mvc;

namespace PraktikumMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            // Secara eksplisit memberitahu MVC untuk menggunakan View dari folder Home
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Validasi sederhana langsung di controller
            if (username == "admin" && password == "123")
            {
                // redirect ke Home kalau berhasil login
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Username atau password salah!";
            // Harus ditentukan juga di sini
            return View("~/Views/Home/Login.cshtml");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
