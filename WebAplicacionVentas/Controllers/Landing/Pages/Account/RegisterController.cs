using Microsoft.AspNetCore.Mvc;

namespace WebAplicacionVentas.Controllers.Landing.Pages.Account
{
    public class RegisterController : Controller
    {
        // GET: RegisterController
        public ActionResult Register() {
            return View("~/Views/Landing/Pages/Account/Register.cshtml");
        }

        public ActionResult Verificacion() {
            return View("~/Views/Landing/Pages/Account/Verificacion.cshtml");
        }

        public ActionResult Pago() {
            return View("~/Views/Landing/Pages/Account/Pago.cshtml");
        }

        public ActionResult Completado() {
            return View("~/Views/Landing/Pages/Account/Completado.cshtml");
        }

        public ActionResult Login() {
            return View("~/Views/Landing/Pages/Account/Login.cshtml");
        }
    }
}
