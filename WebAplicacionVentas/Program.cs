using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using WebAplicacionVentas.Data.Central.Entities;
using WebAplicacionVentas.Data.Ventas.Entities;

var builder = WebApplication.CreateBuilder(args);

// Establecer la cultura predeterminada en ingles
var supportedCultures = new[] { "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Agregar controladores y vistas
builder.Services.AddControllersWithViews()
    .AddDataAnnotationsLocalization()
    .AddViewLocalization();

builder.Services.AddDbContext<CentralDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MevenConnection")));

builder.Services.AddDbContext<VentasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MevenConnection")));

var app = builder.Build();

// Configurar la localizacion
app.UseRequestLocalization(localizationOptions);

// Configuracion del entorno
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
// Configuracion de middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Rutas
app.MapControllerRoute(name: "default", pattern: "{controller=Landing}/{action=Index}/{id?}");
app.Run();