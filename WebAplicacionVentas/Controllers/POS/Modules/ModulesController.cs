using Microsoft.AspNetCore.Mvc;

namespace WebAplicacionVentas.Controllers.POS.Modules
{
    public class ModulesController : Controller
    {
        // GET: ModulesController
        public ActionResult Index()
        {
            return View("~/Views/POS/Index.cshtml");
        }

    }
}
