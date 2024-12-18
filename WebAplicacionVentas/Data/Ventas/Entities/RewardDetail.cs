using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class RewardDetail
{
    public int Id { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? Status { get; set; }

    public int? MaxUses { get; set; }

    public string? RedemptionCode { get; set; }

    public string? Icon { get; set; }

    public int? Priority { get; set; }

    public int RewardId { get; set; }

    public long TransactionId { get; set; }

    public virtual Reward Reward { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
