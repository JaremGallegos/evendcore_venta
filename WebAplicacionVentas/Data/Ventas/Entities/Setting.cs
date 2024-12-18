using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class Setting
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Category { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public byte ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual ICollection<SettingDetail> SettingDetails { get; set; } = new List<SettingDetail>();
}
