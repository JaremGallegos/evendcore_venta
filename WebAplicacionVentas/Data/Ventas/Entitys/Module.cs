using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class Module
{
    public byte Id { get; set; }

    public string ModName { get; set; } = null!;

    public string ModType { get; set; } = null!;

    public bool ModActive { get; set; }

    public string ModRelativeLink { get; set; } = null!;

    public int ModUiOrder { get; set; }

    public string ModDescription { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<ModuleDetail> ModuleDetails { get; set; } = new List<ModuleDetail>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
