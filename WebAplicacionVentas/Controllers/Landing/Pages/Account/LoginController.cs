using Microsoft.AspNetCore.Mvc;

namespace WebAplicacionVentas.Controllers.Landing.Pages.Account
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Login()
        {
            return View("~/Views/Landing/Pages/Account/Login.cshtml");
        }

    }
}
