using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class ProductDetail
{
    public long Id { get; set; }

    public int? OnOrder { get; set; }

    public DateTime? LastNotify { get; set; }

    public string? Problems { get; set; }

    public string? Form { get; set; }

    public string? Size { get; set; }

    public string? Unit { get; set; }

    public string? RelatedCode { get; set; }

    public decimal? CypFactor { get; set; }

    public bool? AllowCombining { get; set; }

    public bool? NoStock { get; set; }

    public bool? Dispensable { get; set; }

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public decimal? TaxRate { get; set; }

    public string? Barcode { get; set; }

    public decimal? Weight { get; set; }

    public string? Dimensions { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public long SupplierId { get; set; }

    public long SettingId { get; set; }

    public long ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Setting Setting { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
