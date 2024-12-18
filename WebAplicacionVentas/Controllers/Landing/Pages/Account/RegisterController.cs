using Microsoft.AspNetCore.Mvc;

namespace WebAplicacionVentas.Controllers.Landing.Pages.Account
{
    public class RegisterController : Controller
    {
        // GET: RegisterController
        public ActionResult RegisterFree() {
            return View("~/Views/Landing/Pages/Account/RegisterFree.cshtml");
        }

        public ActionResult RegisterDemo() {
            return View("~/Views/Landing/Pages/Account/RegisterDemo.cshtml");
        }

        public ActionResult RegisterEnterprise() {
            return View("~/Views/Landing/Pages/Account/RegisterEnterprise.cshtml");
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
