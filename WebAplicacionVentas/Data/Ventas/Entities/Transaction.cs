using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class Transaction
{
    public long Id { get; set; }

    public decimal? Amount { get; set; }

    public string Currency { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Date { get; set; }

    public int TransactionTypeId { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual ICollection<RewardDetail> RewardDetails { get; set; } = new List<RewardDetail>();

    public virtual TransactionType TransactionType { get; set; } = null!;
}
