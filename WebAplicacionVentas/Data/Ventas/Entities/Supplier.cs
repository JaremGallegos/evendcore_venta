using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class Supplier
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public string In { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Direction { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int SupplyTypeId { get; set; }

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual SupplyType SupplyType { get; set; } = null!;
}
