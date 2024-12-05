using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionVentas.Models;

namespace WebAplicacionVentas.Controllers;

public class LandingController : Controller
{
    private readonly ILogger<LandingController> _logger;

    public LandingController(ILogger<LandingController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
