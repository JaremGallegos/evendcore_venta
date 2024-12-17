using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class Sale
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public DateTime Date { get; set; }

    public decimal? TotalAmount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
