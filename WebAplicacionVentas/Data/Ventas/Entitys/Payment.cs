using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class Payment
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public DateTime Date { get; set; }

    public decimal? Amount { get; set; }

    public string Status { get; set; } = null!;

    public long SalesId { get; set; }

    public byte PaymentMethodId { get; set; }

    public long BillingId { get; set; }

    public virtual Billing Billing { get; set; } = null!;

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual Sale Sales { get; set; } = null!;
}
