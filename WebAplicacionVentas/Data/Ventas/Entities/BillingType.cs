using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class BillingType
{
    public byte Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();
}
