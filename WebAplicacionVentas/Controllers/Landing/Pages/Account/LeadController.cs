using Microsoft.AspNetCore.Mvc;

namespace WebAplicacionVentas.Controllers.Landing.Pages.Account
{
    public class LeadController : Controller
    {
        // GET: LeadController
        public ActionResult Demo()
        {
            return View("~/Views/Landing/Pages/Account/Demo.cshtml");
        }

    }
}
