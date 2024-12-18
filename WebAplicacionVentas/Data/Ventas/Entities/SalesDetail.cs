using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class SalesDetail
{
    public long Id { get; set; }

    public string? Notes { get; set; }

    public decimal? Discount { get; set; }

    public decimal? TaxAmount { get; set; }

    public string? DeliveryStatus { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? CouponCode { get; set; }

    public string? SalesChannel { get; set; }

    public long SalesId { get; set; }

    public virtual Sale Sales { get; set; } = null!;
}
