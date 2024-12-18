using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class CustomerReward
{
    public int RewardId { get; set; }

    public long CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Reward Reward { get; set; } = null!;
}
