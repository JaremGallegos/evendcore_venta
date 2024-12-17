using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class PaymentDetail
{
    public long Id { get; set; }

    public string? Reference { get; set; }

    public string? Currency { get; set; }

    public string? Gateway { get; set; }

    public bool? IsRefunded { get; set; }

    public DateTime? RefundDate { get; set; }

    public string? Notes { get; set; }

    public string? ApprovalCode { get; set; }

    public long PaymentId { get; set; }

    public long TransactionId { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
