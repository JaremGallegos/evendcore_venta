using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class Billing
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public DateTime Date { get; set; }

    public string Code { get; set; } = null!;

    public bool Authorized { get; set; }

    public DateTime BillDate { get; set; }

    public DateTime ProcessDate { get; set; }

    public long SupplierId { get; set; }

    public byte BillingTypeId { get; set; }

    public long EmployeeId { get; set; }

    public long CustomerId { get; set; }

    public virtual ICollection<BillingDetail> BillingDetails { get; set; } = new List<BillingDetail>();

    public virtual BillingType BillingType { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Supplier Supplier { get; set; } = null!;
}
