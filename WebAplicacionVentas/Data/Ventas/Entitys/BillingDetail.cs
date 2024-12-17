using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class BillingDetail
{
    public long Id { get; set; }

    public string? Groupname { get; set; }

    public string? Encounter { get; set; }

    public string? CodeText { get; set; }

    public bool? Billed { get; set; }

    public string? Activity { get; set; }

    public string? BillProcess { get; set; }

    public string? ProcessFile { get; set; }

    public string? Modifier { get; set; }

    public int? Units { get; set; }

    public decimal? Fee { get; set; }

    public string? Justify { get; set; }

    public string? Target { get; set; }

    public string? Notecodes { get; set; }

    public decimal? Pricelevel { get; set; }

    public string? RevenueCode { get; set; }

    public string? Chargetcat { get; set; }

    public long ProductId { get; set; }

    public long BillingId { get; set; }

    public virtual Billing Billing { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
