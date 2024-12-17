using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class SettingDetail
{
    public long Id { get; set; }

    public string? Decription { get; set; }

    public bool? IsEditable { get; set; }

    public string? DefaultValue { get; set; }

    public string? Scope { get; set; }

    public bool? RequiresRestart { get; set; }

    public int? LastUpdatedBy { get; set; }

    public int? ValidationRule { get; set; }

    public long SettingId { get; set; }

    public virtual Setting Setting { get; set; } = null!;
}
