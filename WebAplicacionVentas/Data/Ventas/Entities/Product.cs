using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class Product
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public string Name { get; set; } = null!;

    public string CodeNumber { get; set; } = null!;

    public int Stock { get; set; }

    public int MinStock { get; set; }

    public int MaxStock { get; set; }

    public bool Active { get; set; }

    public decimal? Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int ProductCategoryId { get; set; }

    public virtual ICollection<BillingDetail> BillingDetails { get; set; } = new List<BillingDetail>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
