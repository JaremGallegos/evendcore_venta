using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class Section
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Order { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public byte ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;
}
