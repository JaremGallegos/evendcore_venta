namespace WebAplicacionVentas.Models.Landing {
    public class ModuleVM{   
        public string ModName { get; set; } = null!;
        public string ModDescription { get; set; } = null!;
        public int ModUiOrder { get; set; }
        public bool ModActive { get; set; }
    }
}