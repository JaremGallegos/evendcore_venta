using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class SupplyType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
