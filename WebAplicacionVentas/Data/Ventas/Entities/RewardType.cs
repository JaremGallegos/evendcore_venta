using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class RewardType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Reward> Rewards { get; set; } = new List<Reward>();
}
