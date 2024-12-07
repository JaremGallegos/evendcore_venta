using Microsoft.AspNetCore.Mvc;

namespace WebAplicacionVentas.Controllers.Landing.Pages
{
    public class PagesController : Controller
    {
        // GET: PagesController
        public ActionResult Index()
        {
            return View("~/Views/Landing/Pages/Index.cshtml");
        }

    }
}
