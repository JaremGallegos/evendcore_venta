using WebAplicacionVentas.Models.Landing;

namespace WebAplicacionVentas.Models.ViewModels{
    public class LandingVM {
        public List<ContentVM> Content { get; set; } = null!;
        public List<ModuleVM> Modules { get; set; } = null!;
    }
}
