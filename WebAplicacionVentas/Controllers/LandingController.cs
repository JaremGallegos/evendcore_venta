using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionVentas.Models;
using WebAplicacionVentas.Models.Landing;
using WebAplicacionVentas.Models.ViewModels;
using WebAplicacionVentas.Data.Central.Entities;
using WebAplicacionVentas.Data.Ventas.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAplicacionVentas.Controllers;

public class LandingController : Controller
{
    private readonly CentralDbContext _centralContext;
    private readonly VentasDbContext _ventasContext;

    public LandingController(CentralDbContext _centralContext, VentasDbContext _ventasContext)
    {
        this._centralContext = _centralContext;
        this. _ventasContext = _ventasContext;
    }

    public async Task<IActionResult> Index() {
        var content = await _centralContext.Contents.ToListAsync();
        var module = await _ventasContext.Modules.Where(v => v.ModActive).ToListAsync();

        var contentVM = content.Select(c => new ContentVM {
            Title = c.Title,
            Description = c.Description,
        }).ToList();

        var moduleVM = module.Select(v => new ModuleVM {
            ModName = v.ModName,
            ModDescription = v.ModDescription,
            ModUiOrder = v.ModUiOrder,
            ModActive = v.ModActive,
        }).ToList(); 

        var landingVM = new LandingVM {
            Content = contentVM,
            Modules = moduleVM,
        };

        return View(landingVM);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}